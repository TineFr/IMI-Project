using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Mobile.Core.Models;

namespace Imi.Project.Mobile.Core.Services.Mocking.Interfaces
{
    public interface IPrescriptionService
    {
        Task<ObservableCollection<Prescription>> GetAllPrescriptions();
        Task<Prescription> AddPrescription(Species species);
        Task<Species> UpdatePrescription(Species species);
        Task<Species> DeletePrescription(Guid id);
    }
}
