using AprajitaRetails.Utils;
using AprajitaRetailsDataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace AprajitaRetailMonitor.SeviceWorker
{
    public class VBEle
    {
        public const string type = "type";
        public const string bill_number = "bill_number";
        public const string billing_time = "billing_time";
        public const string bill_amount = "bill_amount";
        public const string bill_gross_amount = "bill_gross_amount";
        public const string bill_discount = "bill_discount";
        public const string line_items = "line_items";
        public const string line_item = "line_item";
        public const string line_item_type = "line_item_type";
        public const string serial = "serial";
        public const string item_code = "item_code";
        public const string qty = "qty";
        public const string rate = "rate";
        public const string value = "value";
        public const string discount_value = "discount_value";
        public const string amount = "amount";
        public const string description = "description";

        public const string customer = "customer";
        public const string customername = "name";
        public const string mobile = "mobile";

        public const string Payment_Mode = "Payment_Mode";
        public const string Payment_detail = "Payment_detail";
        public const string payment = "payment";
        public const string mode = "mode";
        public const string Payvalue = "value";
        public const string notes = "notes";

        public const string attributes = "attributes";
        public const string attribute = "attribute";
        public const string name = "name";
        public const string values = "value";

        //Bill Type Service
        public const string PayMode_Type_Details = "PayMode_Type_Details";

        public const string PayMode_Value = "PayMode_Value";
        public const string PayMode_Details = "PayMode_Details";
        public const string bill_store_id = "bill_store_id";
    }

    public class VoygerXMLToLinqDB
    {
        private DataTable vbTable;
        private static Clients client = CurrentClient.LoggedClient;

        public VoygerXMLToLinqDB( )
        {
            vbTable = new DataTable("VoyBill");
        }
    }

    public class VoygerBillWithLinq
    {
        public VoyBill bill;
        public List<VPaymentMode> payModes;
        public List<LineItems> lineItems;

        public VoygerBillWithLinq( )
        {
            bill = new VoyBill();
            lineItems = new List<LineItems>();
            payModes = new List<VPaymentMode>();
        }

        public void AddBillDetails( VoyBill voyBill )
        {
            bill = voyBill;
        }

        public void AddLineItem( LineItems items )
        {
            lineItems.Add(items);
        }

        public void AddPaymentMode( VPaymentMode vPaymentMode )
        {
            payModes.Add(vPaymentMode);
        }
    }

    public class VoyTable
    {
        public const string T_Bill = "bill";
        public const string T_LineItem = "line_item";
        public const string T_Customer = "customer";
        public const string T_Payments = "payment";
    }

    public class VoygerXMLReader
    {
        private static VoygerBillWithLinq vBill;

        // private static XmlTextReader reader;
        private static StreamWriter fileWR;

        /// <summary>
        /// Read Any XML fileinto DataSet
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <returns></returns>
        public static DataSet ReadXML( string xmlFile )
        {
            if (xmlFile == "")
                return null;
            else if (!File.Exists(xmlFile))
            {
                return null;
            }
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlFile, XmlReadMode.InferSchema);
            return dataSet;
        }

        public static DataSet ReadXMLInvoiceToDataSet( string filename )
        {
            DataSet dataSet = ReadXML(filename);
            DataSet InvoiceDataSet = new DataSet("invoiceDataSet");
            if (dataSet != null || dataSet.Tables.Count > 0)
            {
                vBill = new VoygerBillWithLinq();
                foreach (DataTable table in dataSet.Tables)
                {
                    fileWR.WriteLine("TableName: " + table);
                    fileWR.WriteLine();
                    switch (table.TableName)
                    {
                        case VoyTable.T_Bill:
                            ReadBill(table); InvoiceDataSet.Tables.Add(table); break;
                        case VoyTable.T_Customer:
                            ReadCustomer(table);
                            InvoiceDataSet.Tables.Add(table);
                            break;

                        case VoyTable.T_LineItem:
                            ReadLineItems(table);
                            InvoiceDataSet.Tables.Add(table);
                            break;

                        case VoyTable.T_Payments:
                            ReadPaymentDetails(table);
                            InvoiceDataSet.Tables.Add(table);
                            break;

                        default:
                            break;
                    }
                }
                return dataSet;
            }
            else
                return null; // Error: Incase failed to read or no data present
        }

        /// <summary>
        /// read invoicexml
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static VoygerBillWithLinq ReadInvoiceXML( string filename )
        {
            DataSet dataSet = ReadXML(filename);

            if (dataSet != null || dataSet.Tables.Count > 0)
            {
                vBill = new VoygerBillWithLinq();
                foreach (DataTable table in dataSet.Tables)
                {
                    fileWR.WriteLine("TableName: " + table);
                    fileWR.WriteLine();
                    switch (table.TableName)
                    {
                        case VoyTable.T_Bill:
                            ReadBill(table); break;
                        case VoyTable.T_Customer: ReadCustomer(table); break;
                        case VoyTable.T_LineItem: ReadLineItems(table); break;
                        case VoyTable.T_Payments: ReadPaymentDetails(table); break;

                        default:
                            break;
                    }
                }
                return vBill;
            }
            else
                return null; // Error: Incase failed to read or no data present
        }

        /// <summary>
        /// Read voyger bill XML file and process it using DataSet
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <returns>No of table is created</returns>

        public static int ReadVoyBillXML( string xmlFile )
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(xmlFile, XmlReadMode.InferSchema);
            fileWR = File.AppendText(xmlFile + "_DataSet.txt"); //TODO: remove it
            fileWR.WriteLine("xml:{0}: Using DataSet:", xmlFile);
            int c = dataSet.Tables.Count;
            fileWR.WriteLine("No of Table is created in current Data is " + c, xmlFile);
            if (c > 0)
                vBill = new VoygerBillWithLinq();
            else return -1; // Error: Incase failed to read or no data present

            foreach (DataTable table in dataSet.Tables)
            {
                fileWR.WriteLine("TableName: " + table);
                fileWR.WriteLine();
                switch (table.TableName)
                {
                    case VoyTable.T_Bill:
                        ReadBill(table); break;
                    case VoyTable.T_Customer: ReadCustomer(table); break;
                    case VoyTable.T_LineItem: ReadLineItems(table); break;
                    case VoyTable.T_Payments: ReadPaymentDetails(table); break;

                    default:
                        break;
                }
            }

            //WriteVoyDataToFile();
            fileWR.Flush();
            fileWR.Close();
            return c;
        }

        // Read DataTable to Object and verify & process data
        /// <summary>
        /// Read Customer :Datatable to Object
        /// </summary>
        /// <param name="table"></param>
        public static void ReadCustomer( DataTable table )
        {
            vBill.bill.CustomerName = (string)table.Rows[0][VBEle.customername];
            vBill.bill.CustomerMobile = (string)table.Rows[0][VBEle.mobile];
        }

        /// <summary>
        /// Read Line Items details : DataTable to Object
        /// </summary>
        /// <param name="table"></param>
        public static void ReadLineItems( DataTable table )
        {
            LineItems lineItem;
            int id = 0;
            foreach (var row in table.AsEnumerable())
            {
                lineItem = new LineItems();
                lineItem.Amount = Double.Parse((string)row[VBEle.amount]);
                lineItem.Description = (string)row[VBEle.description];
                lineItem.DiscountValue = Double.Parse((string)row[VBEle.discount_value]); ;
                lineItem.ID = ++id;
                lineItem.ItemCode = (string)row[VBEle.item_code];
                lineItem.LineType = (string)row[VBEle.line_item_type];
                lineItem.Qty = Double.Parse((string)row[VBEle.qty]); ;
                lineItem.Rate = Double.Parse((string)row[VBEle.rate]); ;
                lineItem.Serial = Int16.Parse((string)row[VBEle.serial]); ;
                lineItem.Value = Double.Parse((string)row[VBEle.value]); ;
                lineItem.VoyBillId = -1;

                vBill.AddLineItem(lineItem);
            }
        }

        public static void ReadBill( DataTable table )
        {
            vBill.bill.BillAmount = Double.Parse((string)table.Rows[0][VBEle.bill_amount]);
            vBill.bill.BillDiscount = Double.Parse((string)table.Rows[0][VBEle.bill_discount]);
            vBill.bill.BillGrossAmount = Double.Parse((string)table.Rows[0][VBEle.bill_gross_amount]);
            vBill.bill.BillNumber = (string)table.Rows[0][VBEle.bill_number];
            vBill.bill.BillTime = DateTime.Parse((string)table.Rows[0][VBEle.billing_time]);//, "yyyy-MM-dd HH:mm tt", null);
            vBill.bill.BillType = (string)table.Rows[0][VBEle.type];
            vBill.bill.StoreID = (string)table.Rows[0][VBEle.bill_store_id];
            //vBill.bill.ID = -1;
        }

        /// <summary>
        /// PaymentDetails : DataTable To Object
        /// </summary>
        /// <param name="table"></param>
        public static int ReadPaymentDetails( DataTable table )
        {
            VPaymentMode vPayMode;
            int id = 0;
            foreach (var row in table.AsEnumerable())
            {
                vPayMode = new VPaymentMode();
                vPayMode.ID = ++id;
                vPayMode.PaymentMode = (string)row[VBEle.mode];
                vPayMode.PaymentValue = (string)row[VBEle.value];
                vBill.AddPaymentMode(vPayMode);
            }
            return id;
        }
    }// end of class
}