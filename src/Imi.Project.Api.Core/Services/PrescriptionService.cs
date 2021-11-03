using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        protected readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<Prescription> AddPrescriptionAsync(Prescription prescription)
        {
            var result = await _prescriptionRepository.AddAsync(prescription);
            return result;
        }

        public async Task DeleteMultiple(List<Prescription> prescriptions)
        {
            await _prescriptionRepository.DeleteMultipleAsync(prescriptions);
        }

        public async Task DeletePrescriptionAsync(Prescription prescription)
        {
            await _prescriptionRepository.DeleteAsync(prescription);
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(Guid id)
        {
            var prescription = await _prescriptionRepository.GetByIdAsync(id);
            return prescription;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByUserIdAsync(Guid id)
        {
            var prescriptions = await _prescriptionRepository.GetByUserIdAsync(id);
            return prescriptions;
        }

        public async Task<IEnumerable<Prescription>> ListAllPrescriptionsAsync()
        {
            var prescriptions = await _prescriptionRepository.ListAllAsync();
            return prescriptions;
        }

        public async Task<Prescription> UpdatePrescriptionAsync(Prescription prescription)
        {
            var result = await _prescriptionRepository.UpdateAsync(prescription);
            return result;
        }
    }
}
