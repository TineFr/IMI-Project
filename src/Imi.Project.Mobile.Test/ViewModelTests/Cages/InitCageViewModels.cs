using FluentValidation;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels.Cages;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Test.ViewModelTests
{
    public partial class CageViewModelTests
    {

        private AddCageViewModel addCageVm;
        private EditCageViewModel editCageVm;
        private Mock<IBaseApiService<CageRequestModel, CageModel>> _mockBaseService;
        private Mock<IValidator<CageRequestModel>> _mockValidator;


        [SetUp]
        public void Init()
        {
            _mockBaseService = new Mock<IBaseApiService<CageRequestModel, CageModel>>();
            _mockValidator = new Mock<IValidator<CageRequestModel>>();
            addCageVm = new AddCageViewModel(_mockBaseService.Object, _mockValidator.Object);
            editCageVm = new EditCageViewModel(_mockBaseService.Object, _mockValidator.Object);
        }
        public CageModel FillModel()
        {
            return new CageModel { Id = It.IsAny<Guid>() };
        }

        public CageRequestModel FillRequestModel()
        {
            var cageModel = new CageRequestModel();
            cageModel.Name = It.IsAny<string>();
            cageModel.Location = It.IsAny<string>();
            return cageModel;
        }
    }
}
