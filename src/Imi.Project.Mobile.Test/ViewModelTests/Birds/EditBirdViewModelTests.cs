using FluentValidation;
using FluentValidation.Results;
using Imi.Project.Mobile.Core.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imi.Project.Mobile.Test.ViewModelTests.Birds
{
    public partial class BirdViewModelTests
    {

        [Test]
        public void SaveCommand_WithInValidInput_UpdateAsyncDoesNotExecute()
        {
            //arrange
            var bird = FillRequestModel();


            var result = new ValidationResult();
            result.Errors.Add(new ValidationFailure("Name", "NameError"));
            result.Errors.Add(new ValidationFailure("HatchDate", "HatchDateError"));
            result.Errors.Add(new ValidationFailure("Gender", "GenderError"));

            ValidationContext<object> validationContext = new ValidationContext<object>(bird);

            _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
                                                       .Returns(result);
            //act
            editBirdVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.UpdateAsync(It.IsAny<string>(), It.IsAny<BirdRequestModel>()), Times.Never());
            Assert.AreEqual(editBirdVm.NameMessage, result.Errors.Where(e => e.PropertyName == "Name").First().ErrorMessage);
            Assert.AreEqual(editBirdVm.HatchDateMessage, result.Errors.Where(e => e.PropertyName == "HatchDate").First().ErrorMessage);
            Assert.AreEqual(editBirdVm.GenderMessage, result.Errors.Where(e => e.PropertyName == "Gender").First().ErrorMessage);
        }

    }
}
