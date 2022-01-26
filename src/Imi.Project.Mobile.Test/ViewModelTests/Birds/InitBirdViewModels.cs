using FluentValidation;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels.Birds;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Test.ViewModelTests.Birds
{
    public partial class BirdViewModelTests
    {
        private AddBirdViewModel addBirdVm;
        private EditBirdViewModel editBirdVm;
        private Mock<IBaseApiService<BirdRequestModel, BirdModel>> _mockBaseService;
        private Mock<IBaseApiService<CageRequestModel, CageModel>> _mockCageService;
        private Mock<IBaseApiService<SpeciesModel, SpeciesModel>> _mockSpeciesService;
        private Mock<IValidator<BirdRequestModel>> _mockValidator;


        [SetUp]
        public void Init()
        {
            _mockBaseService = new Mock<IBaseApiService<BirdRequestModel, BirdModel>>();
            _mockValidator = new Mock<IValidator<BirdRequestModel>>();
            _mockCageService = new Mock<IBaseApiService<CageRequestModel, CageModel>>();
            _mockSpeciesService = new Mock<IBaseApiService<SpeciesModel, SpeciesModel>>();
            addBirdVm = new AddBirdViewModel(_mockCageService.Object, _mockSpeciesService.Object, _mockBaseService.Object, _mockValidator.Object);
            editBirdVm = new EditBirdViewModel(_mockCageService.Object, _mockSpeciesService.Object, _mockBaseService.Object, _mockValidator.Object);
        }
        public BirdModel FillModel()
        {
            return new BirdModel { Id = It.IsAny<Guid>() };
        }

        public BirdRequestModel FillRequestModel()
        {
            var cageModel = new BirdRequestModel();
            return cageModel;
        }
    }
}
