namespace AprajitaRetailsDB.Models
{
    /// <summary>
    /// TableName : Bank
    /// </summary>
    internal partial class Bank
    {

        public int ID { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public int AccountType { get; set; }
        public string IFSCCode { get; set; }
        public string Branch { get; set; }
        public string BranchCity { get; set; }
    }
}