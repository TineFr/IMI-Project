using FluentValidation;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels.Prescriptions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Test.ViewModelTests
{
    public partial class PrescriptionViewModelTests
    {

        private AddPrescriptionViewModel addPrescriptionVm;
        private Mock<IBaseApiService<PrescriptionRequestModel, PrescriptionModel>> _mockBaseService;
        private Mock<IBaseApiService<BirdRequestModel, BirdModel>> _mockBirdService;
        private Mock<IBaseApiService<MedicineModel, MedicineModel>> _mockMedicineService;
        private Mock<IValidator<PrescriptionRequestModel>> _mockValidator;


        [SetUp]
        public void Init()
        {
            _mockBaseService = new Mock<IBaseApiService<PrescriptionRequestModel, PrescriptionModel>>();
            _mockValidator = new Mock<IValidator<PrescriptionRequestModel>>();
            _mockBirdService = new Mock<IBaseApiService<BirdRequestModel, BirdModel>>();
            _mockMedicineService = new Mock<IBaseApiService<MedicineModel, MedicineModel>>();
            addPrescriptionVm = new AddPrescriptionViewModel(_mockBaseService.Object, _mockMedicineService.Object, _mockBirdService.Object, _mockValidator.Object);

        }
        public PrescriptionModel FillModel()
        {
            return new PrescriptionModel { Id = It.IsAny<Guid>() };
        }

        public PrescriptionRequestModel FillRequestModel()
        {
            var PrescriptionModel = new PrescriptionRequestModel();
            return PrescriptionModel;
        }
    }
}
