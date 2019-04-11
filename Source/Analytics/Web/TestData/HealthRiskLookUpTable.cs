using System.Collections.Generic;

namespace Web.TestData
{
    /// <summary>
    /// Mapping between ECV numbers and name of health risk
    /// </summary>
    public class HealthRiskLookUpTable
    {
        private static Dictionary<int, string> lookupDictionary = new Dictionary<int, string>()
        {
            { 1, "Acute watery diarrhoea " },
            { 2, "Cholera" },
            { 3, "Hepatitis A" },
            { 4, "Hepatitis E" },
            { 5, "Typhoid Fever" },
            { 6, "Acute Respiratory Infections preventable by vaccine" },
            { 7, "Measles" },
            { 8, "Meningococcal Meningitis" },
            { 9, "Polio" },
            { 10, "Chikungunya" },
            { 11, "Dengue fever" },
            { 12, "Malaria" },
            { 13, "Plague" },
            { 14, "Yellow fever" },
            { 15, "Zika virus infection" },
            { 16, "Acute Respiratory Infections" },
            { 17, "Hand, foot and mouth disease (HFMD)" },
            { 18, "Ebola" },
            { 19, "Lassa Fever" },
            { 20, "Marburg" },
            { 21, "Unusual event" },
            { 22, "Anthrax" },
            { 23, "Hantavirus pulmonary syndrome" },
            { 24, "Leptospirosis" },
            { 25, "Middle East respiratory syndrome coronavirus" },
            { 26, "Monkeypox" },
            { 27, "Rift Valley fever " },
            { 28, "Moderate Acute Malnutrition" },
            { 29, "Severe Acute Malnutrition " },
            { 30, "Normal weight" },
            { 31, "Animal die off" }
        };

        public string HealthRiskLookUp(int ECVnumber)
        {
            if (lookupDictionary.ContainsKey(ECVnumber))
            {
                return lookupDictionary[ECVnumber];
            }

            return null;
        }
    }
}
