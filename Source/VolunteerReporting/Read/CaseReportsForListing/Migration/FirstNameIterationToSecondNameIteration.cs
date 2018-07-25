using Infrastructure.Read.Migration;

namespace Read.CaseReportsForListing.Migration
{
    public class FirstNameIterationToSecondNameIteration : IMigrationStrategyFor<CaseReportForListing>
    {
        public CaseReportForListing ApplyMigrationStrategy(CaseReportForListing readModel)
        {
            object males5AndOlder;
            object malesUnder5;
            object females5AndOlder;
            object femalesUnder5;

            if(readModel.ExtraElements.TryGetValue("NumberOfMalesAgedOver4", out males5AndOlder))
            {
                readModel.ExtraElements.Remove("NumberOfMalesAgedOver4");
                if (males5AndOlder != null)
                    readModel.NumberOfMalesAged5AndOlder = (int)males5AndOlder;
            }
            if(readModel.ExtraElements.TryGetValue("NumberOfMalesAges0To4", out malesUnder5))
            {
                readModel.ExtraElements.Remove("NumberOfMalesAges0To4");
                if (malesUnder5 != null)
                    readModel.NumberOfMalesUnder5 = (int)malesUnder5;
            }

            if(readModel.ExtraElements.TryGetValue("NumberOfFemalesAgedOver4", out females5AndOlder))
            {
                readModel.ExtraElements.Remove("NumberOfFemalesAgedOver4");
                if (females5AndOlder != null)
                    readModel.NumberOfFemalesAged5AndOlder = (int)females5AndOlder;
            }
            if(readModel.ExtraElements.TryGetValue("NumberOfFemalesAges0To4", out femalesUnder5))
            {
                readModel.ExtraElements.Remove("NumberOfFemalesAges0To4");
                if (femalesUnder5 != null)
                    readModel.NumberOfFemalesUnder5 = (int)femalesUnder5;
            }

            return readModel;
        }

        public bool CanMigrate(CaseReportForListing readModel)
        {
            if(readModel.ExtraElements == null) return false;
            return readModel.ExtraElements.ContainsKey("NumberOfMalesAgedOver4") ||
                readModel.ExtraElements.ContainsKey("NumberOfMalesAges0To4") ||
                readModel.ExtraElements.ContainsKey("NumberOfFemalesAgedOver4") ||
                readModel.ExtraElements.ContainsKey("NumberOfFemalesAges0To4");
        }
    }
}