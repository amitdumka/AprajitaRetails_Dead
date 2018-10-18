using System;

namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{
    /// <summary>
    /// TableName:Stores
    /// </summary>
    internal class StoresDM
    {
        public int _ID { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string PhoneNo { get; set; }
        public string StoreManagerName { get; set; }
        public string StoreManagerPhoneNo { get; set; }
        public string GSTNO { get; set; }
        public int NoOfEmployees { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Status { get; set; }
    }
}