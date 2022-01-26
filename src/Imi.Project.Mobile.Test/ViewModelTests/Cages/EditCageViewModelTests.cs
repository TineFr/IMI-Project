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
    public partial class CageViewModelTests
    {
        [Test]
        public void SaveCommand_WithInValidInput_UpdateAsyncDoesNotExecute()
        {
            //arrange
            var cage = FillModel();
            editCageVm.Name = cage.Name;
            editCageVm.Location = cage.Location;
            editCageVm.Image = It.IsAny<Stream>();

            var result = new ValidationResult();
            result.Errors.Add(new ValidationFailure("Name", "NameError"));
            result.Errors.Add(new ValidationFailure("Location", "LocationError"));

            ValidationContext<object> validationContext = new ValidationContext<object>(cage);

            _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
                                                       .Returns(result);
            //act
            editCageVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.UpdateAsync($"cages/{It.IsAny<Guid>()}", It.IsAny<CageRequestModel>()), Times.Never());
            Assert.AreEqual(editCageVm.NameMessage, result.Errors.Where(e => e.PropertyName == "Name").First().ErrorMessage);
            Assert.AreEqual(editCageVm.LocationMessage, result.Errors.Where(e => e.PropertyName == "Location").First().ErrorMessage);
        }
    }
}
