using FluentValidation;
using Imi.Project.Mobile.Core.Interfaces;
using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.ViewModels.Medicines;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Test.ViewModelTests
{
    public partial class MedicineViewModelTests
    {

        private AddMedicineViewModel addMedicineVm;
        private EditMedicineViewModel editMedicineVm;
        private Mock<IBaseApiService<MedicineModel, MedicineModel>> _mockBaseService;
        private Mock<IValidator<MedicineModel>> _mockValidator;


        [SetUp]
        public void Init()
        {
            _mockBaseService = new Mock<IBaseApiService<MedicineModel, MedicineModel>>();
            _mockValidator = new Mock<IValidator<MedicineModel>>();
            addMedicineVm = new AddMedicineViewModel(_mockBaseService.Object, _mockValidator.Object);
            editMedicineVm = new EditMedicineViewModel(_mockBaseService.Object, _mockValidator.Object);
        }
        public MedicineModel FillModel()
        {
            return new MedicineModel { Id = It.IsAny<Guid>() };
        }

    }
}
