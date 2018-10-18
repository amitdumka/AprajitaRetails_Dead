namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{
    /// <summary>
    /// TableName : Bank
    /// </summary>
    internal class BankDM
    {
        /// <summary>
        /// Account Type Constants
        /// </summary>
        public enum AccountTypes
        {
            Saving = 1, Current = 2, OverDraft = 3, Other = 4
        }

        public int ID { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public int AccountType { get; set; }
        public string IFSCCode { get; set; }
        public string Branch { get; set; }
        public string BranchCity { get; set; }
    }
}