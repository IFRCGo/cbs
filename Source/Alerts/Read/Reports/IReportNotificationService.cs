namespace Read.Reports
{
    /// <summary>
    /// Interface that will be called for every event for <see cref="Report"/> read model. 
    /// </summary>
    public interface IReportNotificationService
    {
        /// <summary>
        /// Method is called whenever <see cref="Report"/> read model is changed (inserted or updated)
        /// </summary>
        /// <param name="updatedItem">Changed item (inserted or updated)</param>
        void Changed(Report updatedItem);
    }
}
