using FluentValidation;
using FluentValidation.Results;
using Imi.Project.Mobile.Core.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Test.ViewModelTests
{
    public partial class MedicineViewModelTests
    {
        //[Test]
        //public void SaveCommand_WithValidInput_UpdateAsyncExecutesOnce()
        //{
        //    //arrange
        //    var Medicine = FillRequestModel();
        //    editMedicineVm.Name = Medicine.Name;
        //    editMedicineVm.Location = Medicine.Location;
        //    editMedicineVm.Image = It.IsAny<Stream>();


        //    ValidationContext<object> validationContext = new ValidationContext<object>(Medicine);

        //    _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
        //                                               .Returns(new ValidationResult());
        //    _mockBaseService.Setup(bs => bs.UpdateAsync(It.IsAny<string>(), It.IsAny<MedicineRequestModel>())).Returns(It.IsAny<Task<MedicineModel>>());
        //    //act
        //    editMedicineVm.Init(FillModel());
        //    editMedicineVm.SaveCommand.Execute(null);
        //    //assert
        //    _mockBaseService.Verify(br => br.UpdateAsync(It.IsAny<string>(), It.IsAny<MedicineRequestModel>()), Times.Once());

        //}


        [Test]
        public void SaveCommand_WithInValidInput_UpdateAsyncDoesNotExecute()
        {
            //arrange
            var Medicine = FillModel();


            var result = new ValidationResult();
            result.Errors.Add(new ValidationFailure("Name", "NameError"));
            result.Errors.Add(new ValidationFailure("Usage", "UsageError"));

            ValidationContext<object> validationContext = new ValidationContext<object>(Medicine);

            _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
                                                       .Returns(result);
            //act
            editMedicineVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.UpdateAsync($"Medicines/{It.IsAny<Guid>()}", It.IsAny<MedicineModel>()), Times.Never());
            Assert.AreEqual(editMedicineVm.NameMessage, result.Errors.Where(e => e.PropertyName == "Name").First().ErrorMessage);
            Assert.AreEqual(editMedicineVm.UsageMessage, result.Errors.Where(e => e.PropertyName == "Usage").First().ErrorMessage);
        }
    }
}
