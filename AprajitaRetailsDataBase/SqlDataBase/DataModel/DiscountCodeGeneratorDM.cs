using System;

namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{
    internal class DiscountCodeGeneratorDM
    {
        public int ID { set; get; }
        public string DiscountCode { set; get; }
        public DateTime GenDate { set; get; }
        //TODO: Implement with full secure
    }
}