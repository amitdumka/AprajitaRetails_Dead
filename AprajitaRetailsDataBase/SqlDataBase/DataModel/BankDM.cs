namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{

    /// <summary>
    /// TableName : Bank
    /// </summary>
    public class BankDM
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