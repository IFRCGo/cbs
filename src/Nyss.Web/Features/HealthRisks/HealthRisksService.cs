using System.Collections.Generic;
using System.Linq;

namespace Nyss.Web.Features.HealthRisks
{
    public class HealthRisksService : IHealthRisksService
    {
        public IEnumerable<HealthRiskViewModel> All()
        {
            return HealthRiskViewModels;
        }

        public HealthRiskViewModel GetByCode(string code)
        {
            return HealthRiskViewModels.FirstOrDefault(_ => _.Code == code);
        }

        private static readonly HealthRiskViewModel[] HealthRiskViewModels =
        {
            new HealthRiskViewModel { Code = "1", DisplayName = "Acute diarrhoeal disease" },
            new HealthRiskViewModel { Code = "2", DisplayName = "Cholera" },
            new HealthRiskViewModel { Code = "3", DisplayName = "Hepatitis A" },
            new HealthRiskViewModel { Code = "4", DisplayName = "Hepatitis E" },
            new HealthRiskViewModel { Code = "5", DisplayName = "Typhoid fever" },
            new HealthRiskViewModel { Code = "6", DisplayName = "Acute bloody diarrhoea" },
            new HealthRiskViewModel { Code = "7", DisplayName = "Acute respiratory infections preventable by vaccine (Diphtheria, Mumps, Rubella, Chickenpox, Whooping cough)" },
            new HealthRiskViewModel { Code = "8", DisplayName = "Measles" },
            new HealthRiskViewModel { Code = "9", DisplayName = "Meningococcal meningitis" },
            new HealthRiskViewModel { Code ="10", DisplayName = "Polio" },
            new HealthRiskViewModel { Code ="11", DisplayName = "Yellow fever" },
            new HealthRiskViewModel { Code ="12", DisplayName = "Chikungunya" },
            new HealthRiskViewModel { Code ="13", DisplayName = "Dengue fever" },
            new HealthRiskViewModel { Code ="14", DisplayName = "Malaria" },
            new HealthRiskViewModel { Code ="15", DisplayName = "Zika virus disease" },
            new HealthRiskViewModel { Code ="16", DisplayName = "Acute respiratory infections (ARIs)" },
            new HealthRiskViewModel { Code ="17", DisplayName = "Ebola virus disease" },
            new HealthRiskViewModel { Code ="18", DisplayName = "Lassa fever" },
            new HealthRiskViewModel { Code ="19", DisplayName = "Marburg haemorrhagic fever" },
            new HealthRiskViewModel { Code ="20", DisplayName = "Plague" },
            new HealthRiskViewModel { Code ="21", DisplayName = "Anthrax" },
            new HealthRiskViewModel { Code ="22", DisplayName = "Hantavirus pulmonary syndrome (HPS)" },
            new HealthRiskViewModel { Code ="23", DisplayName = "Leptospirosis" },
            new HealthRiskViewModel { Code ="24", DisplayName = "Middle East respiratory syndrome coronavirus (MERS-CoV)" },
            new HealthRiskViewModel { Code ="25", DisplayName = "Monkeypox" },
            new HealthRiskViewModel { Code ="26", DisplayName = "Rift Valley fever" },
            new HealthRiskViewModel { Code ="27", DisplayName = "Hand, foot and mouth disease (HFMD)" },
            new HealthRiskViewModel { Code ="28", DisplayName = "Cluster of unexplained illnesses or deaths" },
            new HealthRiskViewModel { Code ="29", DisplayName = "Acute malnutrition" },
        };
    }
}
