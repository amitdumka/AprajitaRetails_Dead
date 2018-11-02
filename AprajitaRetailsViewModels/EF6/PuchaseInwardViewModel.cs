using AprajitaRetailsDB.DataBase.AprajitaRetails;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AprajitaRetailsViewModels.EF6
{
    public class PuchaseInwardViewModel:IDisposable
    {
        AprajitaRetailsMainDB mainDB; 

        public PuchaseInwardViewModel( )
        {
            mainDB=new AprajitaRetailsMainDB();
        }

        public void Dispose( )
        {
            ((IDisposable)mainDB).Dispose();
        }


        #region GetData
        public List<string> GetProductTypeNameList( )
        {
            mainDB.ProductTypes.Load();
            return mainDB.ProductTypes.Local.Select( s => s.ProductTypeName ).ToList();
        }
        public string GetProductType(int id )
        {
            mainDB.ProductTypes.Load();
            return mainDB.ProductTypes.Local.Where( s => s.ProductTypeID==id ).FirstOrDefault().ProductTypeName;

        }
        public int GetProductTypeID(string pTypes )
        {
            mainDB.ProductTypes.Load();
            return mainDB.ProductTypes.Local.Where( s => s.ProductTypeName==pTypes ).FirstOrDefault().ProductTypeID;
        }
        public decimal GetFrieghtCharge(string pTypes )
        {
            mainDB.ProductTypes.Load();
            return mainDB.ProductTypes.Local.Where( s => s.ProductTypeName==pTypes ).FirstOrDefault().RateOfFrieghtCharged??0;
        }
        public decimal GetFrieghtCharge( int pTypeID )
        {
            mainDB.ProductTypes.Load();
            return mainDB.ProductTypes.Local.Where( s => s.ProductTypeID==pTypeID ).FirstOrDefault().RateOfFrieghtCharged??0;
        }

        public List<string> GetGRNNoList( )
        {
            mainDB.PurchaseInwards.Load();
           return mainDB.PurchaseInwards.Local.Select( s => s.GRNNo ).ToList();
        }

        public PurchaseInward GetPurchaseInwardDetails(string grnNo )
        {
            mainDB.PurchaseInwards.Load();
            return mainDB.PurchaseInwards.Local.Where(s=>s.GRNNo==grnNo).FirstOrDefault();
        }
        public PurchaseInward GetPurchaseInwardDetails( int id )
        {
            mainDB.PurchaseInwards.Load();
            return mainDB.PurchaseInwards.Local.Where( s => s.PurchaseInwardID==id ).FirstOrDefault();
        }
        public PurchaseInward GetPurchaseInwardDetailsByInvNo( string invNo )
        {
            mainDB.PurchaseInwards.Load();
            return mainDB.PurchaseInwards.Local.Where( s => s.InvoiceNo==invNo ).FirstOrDefault();
        }
        public decimal CalculateFrieghtCharge(ProductType productType, decimal qty )
        {
            decimal fCharge = qty*productType.RateOfFrieghtCharged??0;
            return fCharge;
        }
        public decimal CalculateFrieghtCharge( decimal rate, decimal qty )
        {
            decimal fCharge = qty*rate;
            return fCharge;
        }
        public bool IsStockCorrect(int stockState )
        {
            return Basic.IntToBool( stockState );
        }
        public bool IsPaidBill(int paid )
        {
            return Basic.IntToBool( paid );
        }

        #endregion


        public int Save(PurchaseInward inward )
        {
            mainDB.PurchaseInwards.Add( inward );
            return mainDB.SaveChanges();
        }
    }
}
