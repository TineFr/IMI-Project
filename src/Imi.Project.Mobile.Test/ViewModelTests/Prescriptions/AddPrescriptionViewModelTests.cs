using FluentValidation;
using FluentValidation.Results;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels.Prescriptions;
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
    public partial class PrescriptionViewModelTests
    {

        [Test]
        public void SaveCommand_WithValidInput_AddAsyncExecutesOnce()
        {
            //arrange
            var prescription = FillRequestModel();

            

            ValidationContext<object> validationContext = new ValidationContext<object>(prescription);

            _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
                                                       .Returns(new ValidationResult());
            //act
            addPrescriptionVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.AddAsync($"prescriptions", It.IsAny<PrescriptionRequestModel>()), Times.Once());

        }


        [Test]
        public void SaveCommand_WithInValidInput_AddAsyncDoesNotExecute()
        {
            //arrange
            var Prescription = FillRequestModel();


            var result = new ValidationResult();
            result.Errors.Add(new ValidationFailure("Medicine", "MedicineError"));
            result.Errors.Add(new ValidationFailure("Birds", "BirdsError"));
            result.Errors.Add(new ValidationFailure("StartDate", "StartDateError"));
            result.Errors.Add(new ValidationFailure("EndDate", "EndDateError"));
            ValidationContext<object> validationContext = new ValidationContext<object>(Prescription);

            _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
                                                       .Returns(result);
            //act
            addPrescriptionVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.AddAsync("Prescriptions", It.IsAny<PrescriptionRequestModel>()), Times.Never());
            Assert.AreEqual(addPrescriptionVm.MedicineMessage, result.Errors.Where(e => e.PropertyName == "Medicine").First().ErrorMessage);
            Assert.AreEqual(addPrescriptionVm.BirdsMessage, result.Errors.Where(e => e.PropertyName == "Birds").First().ErrorMessage);
            Assert.AreEqual(addPrescriptionVm.StartDateMessage, result.Errors.Where(e => e.PropertyName == "StartDate").First().ErrorMessage);
            Assert.AreEqual(addPrescriptionVm.EndDateMessage, result.Errors.Where(e => e.PropertyName == "EndDate").First().ErrorMessage);
        }
    }
}
