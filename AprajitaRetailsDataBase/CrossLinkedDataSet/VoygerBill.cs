using AprajitaRetailsDataBase.LinqDataBase;
using System.Collections.Generic;

namespace AprajitaRetailsDataBase.DataTypes
{
    public class VoygerBill
    {
        public VoyBill bill;
        public List<VPaymentMode> payModes;
        public List<LineItems> lineItems;

        public VoygerBill( )
        {
            bill=new VoyBill();
            lineItems=new List<LineItems>();
            payModes=new List<VPaymentMode>();
        }

        public void AddBillDetails( VoyBill voyBill )
        {
            bill=voyBill;
        }

        public void AddLineItem( LineItems items )
        {
            lineItems.Add( items );
        }

        public void AddPaymentMode( VPaymentMode vPaymentMode )
        {
            payModes.Add( vPaymentMode );
        }
    }
}