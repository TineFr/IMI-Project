using Imi.Project.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Domain.Services.Mocking.Services
{
    public class MockMedicationService : IMedicationService
    {
        private static ObservableCollection<Medication> medicationrepository = new ObservableCollection<Medication>
        {
                    new Medication
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "   Acox",
                    Usage = "7 ml per liter drinking water",
                    Birds = new List<Guid>
                    {
                        Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                        Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422")
                    },
                    
                    },
                    new Medication
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "   Acox",
                    Usage = "7 ml per liter drinking water",
                    Birds = new List<Guid>
                    {
                        Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                        Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422")
                    },
                    },
                    new Medication
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "   Acox",
                    Usage = "7 ml per liter drinking water",
                    Birds = new List<Guid>
                    {
                        Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                        Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422")
                    },
                    },
                    new Medication
                    {
                    Id = Guid.Parse("C46C8A99-382C-426E-A8A5-4DF55A3FE2C0"),
                    Name = "   Acox",
                    Usage = "7 ml per liter drinking water",
                    Birds = new List<Guid>
                    {
                        Guid.Parse("8E74A018-6D85-4E2A-BB85-F8DA2D58F3BF"),
                        Guid.Parse("6668E055-E99C-4B50-AD12-5A28CA2AD422"),
                        Guid.Parse("8606C209-1D51-4EE3-9F8D-8DE3D0F3F24E"),
                        Guid.Parse("F797C0C1-B01A-4F54-9C5D-7C66D5EDDC52")
                    },
                    },



        };
        public Task<Medication> AddMedication(Medication Medication)
        {
            throw new NotImplementedException();
        }

        public Task<Medication> DeleteMedication(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Medication>> GetAllMedications()
        {
            return Task.FromResult( medicationrepository);
        }

        public Task<Medication> GetMedicationById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Medication> UpdateMedication(Medication Medication)
        {
            throw new NotImplementedException();
        }
    }
}
