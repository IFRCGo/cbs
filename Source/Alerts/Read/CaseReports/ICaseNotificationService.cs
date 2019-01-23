namespace Read.CaseReports
{
    /// <summary>
    /// Interface that will be called for every event for <see cref="Case"/> read model. 
    /// </summary>
    public interface ICaseNotificationService
    {
        /// <summary>
        /// Method is called whenever <see cref="Case"/> read model is changed (inserted or updated)
        /// </summary>
        /// <param name="updatedItem">Changed item (inserted or updated)</param>
        void Changed(Case updatedItem);
    }
}
