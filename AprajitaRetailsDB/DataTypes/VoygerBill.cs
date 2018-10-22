using AprajitaRetailsDB.Models.Voyger;
using System.Collections.Generic;

namespace AprajitaRetailsDB.DataTypes
{
    public class VoygerBill
    {
        public VoyBill bill;
        public List<VPaymentMode> payModes;
        public List<LineItem> lineItems;

        public VoygerBill( )
        {
            bill = new VoyBill();
            lineItems = new List<LineItem>();
            payModes = new List<VPaymentMode>();
        }

        public void AddBillDetails( VoyBill voyBill )
        {
            bill = voyBill;
        }

        public void AddLineItem( LineItem items )
        {
            lineItems.Add(items);
        }

        public void AddPaymentMode( VPaymentMode vPaymentMode )
        {
            payModes.Add(vPaymentMode);
        }
    }
}