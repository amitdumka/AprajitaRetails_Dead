using AprajitaRetailsDataBase.SqlDataBase.Data;
using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

//using System.Drawing.Printing;
//using System.Windows.Forms;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class SaleInvoiceVM
    {
        //Fields
        private SalesmanDB smDB;

        private SaleInvoiceDB sDB;
        private ProductItemsDB pDB;
        private SaleItemsDB siDB;
        private CardPaymentDB cpDB;
        private PaymentDetailDB payDB;
        private const string ManualSeries = "MI";
        private const long SeriesStart = 10000000;

        //Constructor
        public SaleInvoiceVM( )
        {
            smDB = new SalesmanDB();
            sDB = new SaleInvoiceDB();
            pDB = new ProductItemsDB();
            siDB = new SaleItemsDB();
            payDB = new PaymentDetailDB();
            cpDB = new CardPaymentDB();
        }

        public void SampleSalesman( )
        {
            smDB.SampleData();
        }

        public List<Salesman> GetSalesmanList( )
        {
            return smDB.GetAllRecord();
        }

        public List<string> GetSalesmanNameList( )
        {
            List<string> list = new List<string>();
            List<Salesman> salesman = smDB.GetAllRecord();
            foreach (Salesman data in salesman)
            {
                list.Add(data.SalesmanName);
            }
            return list;
        }

        public string GetSalesmanName( int id )
        {
            if (id > 0)
                return smDB.GetByID(id).SalesmanName;
            else
                return "NotFound";
        }

        public string GetSalesmanName( string smcode )
        {
            if (smcode != null && smcode != "")
                return smDB.GetByColName("SMCode", smcode).SalesmanName;
            return "NotFound";
        }

        public int GetSalesmanID( string salesmanname, string smcode )
        {
            if (salesmanname != null && salesmanname != "")
                return smDB.GetID("SalesmanName", salesmanname);

            if (smcode != null && smcode != "")
                return smDB.GetID("SMCode", smcode);
            return -1;
        }

        public string GetSalesmanCode( int id )
        {
            if (id > 0)
                return smDB.GetByID(id).SMCode;
            else
                return "NotFound";
        }

        public string GetSalesmanCode( string salesman )
        {
            if (salesman != null && salesman != "")
                return smDB.GetByColName("SalesmanName", salesman).SMCode;
            return "NotFound";
        }

        public List<string> GetBarCodesList( int x )
        {
            return pDB.GetBarCodeList(x);
        }

        //Functions/Methods
        public void AddData( ) { }

        public int SaveInvoiceData( SaleInvoice saleInv, DataTable itemTable, SalePaymentDetails payDetails )
        {    //TODO: Urgent SaveInoviceData.
            int status = SaveData(saleInv);
            if (status > 0)
            {
                string invNo = sDB.GetLastInvoiceNo();
                status = SaveItemsDetails(itemTable);
                if (status > 0)
                {
                    payDetails.InvoiceNo = invNo;
                    int status2 = -1;
                    bool modef = false;
                    if (payDetails.PayMode == UtilOps.GetSalePayMode(SalePayMode.Card) || payDetails.PayMode == UtilOps.GetSalePayMode(SalePayMode.Mix))
                    {
                        modef = true;
                        payDetails.CardDetails.InvoiceNo = invNo;
                        status2 = SaveCardDetails(payDetails.CardDetails);
                        int cardDetailsId = 0;
                        status = SavePaymentDetails(payDetails, cardDetailsId);
                    }
                    else
                    {
                        //For CashPayment
                        status = SavePaymentDetails(payDetails, -1);
                    }

                    if (modef && status > 0 && status2 > 0)
                    {
                        return 1;
                    }
                    else if (modef == false && status > 0)
                        return 1;
                    else if (modef && status <= 0 || status2 <= 0)
                        return -3;
                    else
                        return -4;
                    //TODO: Make Error Code so easy to debug and handle
                }
                else
                    return -2;
            }
            else
            {
                return -1;
            }
        }

        public int SaveData( SaleInvoice obj )
        {
            return sDB.InsertData(obj);
        }

        public int SaveItemsDetails( DataTable itemTable )
        {
            return siDB.InsertData(itemTable);
        }

        public int SavePaymentDetails( SalePaymentDetails pd, int cardDetailsID )
        {
            PaymentDetails payDetails = new PaymentDetails()
            {
                CardAmount = pd.CardAmount,
                CashAmount = pd.CashAmount,
                InvoiceNo = pd.InvoiceNo,
                PayMode = pd.PayMode,
                CardDetailsID = cardDetailsID,
                ID = pd.ID
            };
            return payDB.InsertData(payDetails);
        }

        public int SaveCardDetails( CardPaymentDetails cardDetails )
        {
            return cpDB.InsertData(cardDetails);
        }

        public List<string> GetInvoiceNoList( )
        {
            return sDB.GetInvoiceList();
        }

        public SortedDictionary<string, string> GetCustomerInfo( string mobileNo )
        {
            if (mobileNo.Trim().Length <= 0)
                return null;
            return sDB.GetCustomerInfo(0, mobileNo, 2);
        }

        public SortedDictionary<string, string> GetCustomerInfo( int custId )
        {
            return sDB.GetCustomerInfo(custId, "", 1);
        }

        public List<string> GetCustomerMobileNoList( )
        {
            return sDB.GetCustomerMobileList();
        }

        public List<SortedDictionary<string, string>> GetItemDetails( string barcode )
        {
            return sDB.GetItemDetails(barcode);
        }

        public ProductItems GetProductItemDetais( string barcode )
        {
            return pDB.GetProductItemDetais(barcode);
        }

        //Calucation Section
        public void CalculateTotalSaleAmount( ) { }

        public void CalculateTotalTaxAmount( )
        {
        }

        public void CalculateTotalDiscountAmount( )
        {
        }

        public SortedDictionary<string, string> GetInvoiceDetails( string invoiceNo )
        {
            throw new NotImplementedException();
        }

        public int GetInvoiceNoList( ComboBox cBInvoiceNo )
        {
            List<string> itemList = GetInvoiceNoList();
            foreach (string item in itemList)
            {
                cBInvoiceNo.Items.Add(item);
            }
            return itemList.Count;
        }

        public int GetCustomerMobileNoList( ComboBox cBMobileNo )
        {
            List<string> itemList = GetCustomerMobileNoList();
            foreach (string item in itemList)
            {
                cBMobileNo.Items.Add(item);
            }
            return itemList.Count;
        }

        public InvoiceNo GenerateInvoiceNo( )
        {
            InvoiceNo inv = new InvoiceNo(ManualSeries);
            //TODO: series Start should be changed every Finnical Year;
            //TODO: Should have option to check data and based on that generate it
            string iNo = sDB.GetLastInvoiceNo();
            if (iNo.Length > 0)
            {
                if (iNo != "0")
                {
                    Logs.LogMe("Inv=" + iNo);
                    iNo = iNo.Substring(5);
                    Logs.LogMe("Inv=" + iNo);
                    long i = long.Parse(iNo);
                    Logs.LogMe("Inv=" + i);
                    inv.TP = i + 1;
                }
                else
                { inv.TP = SeriesStart + 1; }
            }
            else
            {
                //TODO: check future what happens and what condtion  come here
                inv.TP = SeriesStart + 1;
                Logs.LogMe("Future check :Inv=" + inv.TP);
            }
            return inv;
        }
    }

    //-------------------------------------------------------------------------
}