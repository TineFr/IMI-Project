using FluentValidation;
using FluentValidation.Results;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels.Cages;
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
    public partial class CageViewModelTests
    {

        [Test]
        public void SaveCommand_WithValidInput_AddAsyncExecutesOnce()
        {
            //arrange
            var cage = FillRequestModel();
            addCageVm.Name = cage.Name;
            addCageVm.Location = cage.Location;
            addCageVm.Image = It.IsAny<Stream>();
            

            ValidationContext<object> validationContext = new ValidationContext<object>(cage);

            _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
                                                       .Returns(new ValidationResult());
            //act
            addCageVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.AddAsync($"cages", It.IsAny<CageRequestModel>()), Times.Once());

        }


        [Test]
        public void SaveCommand_WithInValidInput_AddAsyncDoesNotExecute()
        {
            //arrange
            var cage = FillRequestModel();
            addCageVm.Name = cage.Name;
            addCageVm.Location = cage.Location;
            addCageVm.Image = It.IsAny<Stream>();

            var result = new ValidationResult();
            result.Errors.Add(new ValidationFailure("Name", "NameError"));
            result.Errors.Add(new ValidationFailure("Location", "LocationError"));

            ValidationContext<object> validationContext = new ValidationContext<object>(cage);

            _mockValidator.Setup(validator => validator.Validate(It.IsAny<IValidationContext>()))
                                                       .Returns(result);
            //act
            addCageVm.SaveCommand.Execute(null);
            //assert
            _mockBaseService.Verify(br => br.AddAsync("cages", It.IsAny<CageRequestModel>()), Times.Never());
            Assert.AreEqual(addCageVm.NameMessage, result.Errors.Where(e => e.PropertyName == "Name").First().ErrorMessage);
            Assert.AreEqual(addCageVm.LocationMessage, result.Errors.Where(e => e.PropertyName == "Location").First().ErrorMessage);
        }
    }
}
