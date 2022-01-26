using FluentValidation;
using FluentValidation.Results;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels.Medicines;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Imi.Project.Mobile.Test.ViewModelTests
{
    public partial class MedicineViewModelTests
    {

        [Test]
        public void SaveCommand_WithValidInput_AddAsyncExecutesOnce()
        {
            //arrange
            var Medicine = FillModel();

            

            ValidationContext<object> validationContext = new ValidationContext<object>(Medicine);

            _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
                                                       .Returns(new ValidationResult());
            //act
            addMedicineVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.AddAsync($"medicines", It.IsAny<MedicineModel>()), Times.Once());

        }


        [Test]
        public void SaveCommand_WithInValidInput_AddAsyncDoesNotExecute()
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
            addMedicineVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.AddAsync("medicines", It.IsAny<MedicineModel>()), Times.Never());
            Assert.AreEqual(addMedicineVm.NameMessage, result.Errors.Where(e => e.PropertyName == "Name").First().ErrorMessage);
            Assert.AreEqual(addMedicineVm.UsageMessage, result.Errors.Where(e => e.PropertyName == "Usage").First().ErrorMessage);
        }
    }
}
