using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    class AprajitaRetailsMainDBSeeder : DropCreateDatabaseAlways<AprajitaRetailsMainDB>
    {
        protected override void Seed( AprajitaRetailsMainDB context )
        {
            IList<ExpensesCategory> defaultExpCat = new List<ExpensesCategory>();
            defaultExpCat.Add( new ExpensesCategory() { Category="Flowers", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Snacks", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Coffee", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Water", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Cutlerys", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Chanda", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Marketing", Level=2 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Priniting", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Holding Rent", Level=2 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Last Pcs", Level=2 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Incentive(General)", Level=3 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Rent", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Eletricity Bill", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Reparing", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Material Purchase", Level=1 } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Store Assest", Level=4 } );
            defaultExpCat.Add( new ExpensesCategory()
            {
                Category="Computer & Accessiory",
                Level=
                4
            } );
            defaultExpCat.Add( new ExpensesCategory() { Category="Stationery", Level=1 } );
            context.ExpensesCategories.AddRange( defaultExpCat );

            IList<PaymentMode> paymode = new List<PaymentMode>();
            paymode.Add( new PaymentMode() { PayMode="Cash" } );
            paymode.Add( new PaymentMode() { PayMode="Debit Card" } );
            paymode.Add( new PaymentMode() { PayMode="Credit Card" } );
            paymode.Add( new PaymentMode() { PayMode="UPI" } );
            paymode.Add( new PaymentMode() { PayMode="PayTM" } );
            paymode.Add( new PaymentMode() { PayMode="Mix" } );
            paymode.Add( new PaymentMode() { PayMode="Coupon" } );
            paymode.Add( new PaymentMode() { PayMode="Cheque" } );
            paymode.Add( new PaymentMode() { PayMode="RTGS" } );
            paymode.Add( new PaymentMode() { PayMode="NEFT" } );
            paymode.Add( new PaymentMode() { PayMode="IMPS" } );
            paymode.Add( new PaymentMode() { PayMode="PaymentApp" } );
            paymode.Add( new PaymentMode() { PayMode="Bank Transfer" } );
            paymode.Add( new PaymentMode() { PayMode="Others" } );
            context.PaymentModes.AddRange( paymode );

            IList<SaleType> saleTypes = new List<SaleType>();
            saleTypes.Add ( new SaleType() {ISVoyger=1, SaleTypeName="Regular" } );
            saleTypes.Add( new SaleType() { ISVoyger=1, SaleTypeName="Sale Return" } );
            saleTypes.Add( new SaleType() { ISVoyger=2, SaleTypeName="Manual Sale" } );
            saleTypes.Add( new SaleType() { ISVoyger=2, SaleTypeName="Manual Sale Return" } );
            context.SaleTypes.AddRange( saleTypes );

            IList<User> users = new List<User>();
            users.Add( new User() {passwd="admin" ,role=1, StoreCode="Jh006", username="admin_006"} );
            users.Add( new User() { passwd="admin", role=1, StoreCode="Jh014", username="admin_014" } );
            users.Add( new User() { passwd="nuser", role=2, StoreCode="Jh006", username="nuser_006" } );
            users.Add( new User() { passwd="nuser", role=2, StoreCode="Jh014", username="nuser_014" } );
            context.Users.AddRange( users );

            IList<Unit> units = new List<Unit>();

            units.Add( new Unit() {UnitName="MTRS" } );

            units.Add( new Unit() { UnitName="PCS" } );

            units.Add( new Unit() { UnitName="Nos" } );
            context.Units.AddRange( units );

            base.Seed( context );
        }
    }
}