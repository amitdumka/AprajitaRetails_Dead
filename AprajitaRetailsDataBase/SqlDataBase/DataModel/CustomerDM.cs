namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{
    /// <summary>
    /// TableName: Customer
    /// </summary>
    internal class CustomerDM
    {
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string City { set; get; }
        public string MobileNo { set; get; }
        public string EMailID { set; get; }
        public int NoOfBills { set; get; }
        public double TotalAmount { set; get; }
    }
}