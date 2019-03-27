namespace Read.CaseReports
{
    public class CaseReportsEventHandler : ICaseReportsEventHandler
    {
        private readonly MongoDBHandler _dbHandler;

        public CaseReportsEventHandler(MongoDBHandler dbHandler)
        {
            _dbHandler = dbHandler;
        }

        public void Handle(CaseReport caseReport)
        {
            //_dbHandler.InsertRecordToDB()
        }
    }
}