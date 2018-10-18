namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{
    /// <summary>
    ///  TableName : BankDetails
    /// </summary>
    internal class BankDetailsDM
    {
        public int ID { get; set; }
        public int BankID { get; set; }
        public int TranscationType { get; set; }
        public string BankRef { get; set; }
        public string TranscationRef { get; set; }
    }
}