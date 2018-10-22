namespace AprajitaRetailsDB.Models.Data
{
    /// <summary>
    ///  TableName : BankDetails
    /// </summary>
    public class BankDetails
    {
        public int ID { get; set; }
        public string RefID { set; get; }
        public int BankID { get; set; }
        public int TranscationType { get; set; }
        public string BankRef { get; set; }
        public string TranscationRef { get; set; }
    }
}