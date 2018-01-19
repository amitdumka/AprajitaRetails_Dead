using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;

namespace AprajitaRetails.Voy
{
    class VBillToDB
    {
        DataTable vbTable;
        public VBillToDB()
        {
            vbTable = new DataTable ("VoyBill");

        }

        public void ToTable(VBill bill)
        {

        }

    }
    internal class VBill
    {
        public VoyBill bill;
        public List<VPaymentMode> payModes;
        public List<LineItems> lineItems;

        public VBill()
        {
            bill = new VoyBill ();
            lineItems = new List<LineItems> ();
            payModes = new List<VPaymentMode> ();
        }
    }

    internal class VoyBillUpload
    {
        private static VBill vBill;
        private static XmlTextReader reader;
        public static void WriteToText(string fname)
        {
            using ( StreamWriter w = File.AppendText (fname) )
            {
                w.WriteLine ("Mobile: {0}\t Name: {1}", vBill.bill.CustomerMobile, vBill.bill.CustomerName);
                w.WriteLine ("Type:{1}\t Inv:{1}", vBill.bill.BillType, vBill.bill.BillNumber);
                w.WriteLine ("Amount:{0}\t Discount:{1}\t Gross:{2}",
                vBill.bill.BillAmount, vBill.bill.BillDiscount, vBill.bill.BillGrossAmount);
            }
        }
        static StreamWriter ws;
        public static void ReadVoyBillXML(string fileName)
        {
            ws = File.AppendText (fileName + "_2.txt");
            ws.WriteLine ("xml:{0}: doing ops:", fileName);
            vBill = new VBill ();
            reader = new XmlTextReader (fileName);
            while ( reader.Read () )
            {
                if ( reader.NodeType == XmlNodeType.Element )
                {
                    ReadElement ();
                }
                else if ( reader.NodeType == XmlNodeType.EndElement )
                {
                    ReadEndElement ();
                }
            }
            WriteToText (fileName + ".txt");
            ws.Flush ();
            ws.Close ();
        }

        protected static void ReadElement()
        {
            switch ( reader.Name )
            {
                case VBEle.customer:
                    ws.WriteLine ("Reading Customer Data");
                    ReadCustomer ();
                    break;

                case VBEle.line_items:
                    ws.WriteLine ("Reading LineItems");
                    ReadLineItems ();
                    break;

                case VBEle.Payment_Mode:
                    ws.WriteLine ("Reading PayMode");
                    ReadPayMode ();
                    break;

                case VBEle.type:
                    reader.Read ();
                    vBill.bill.BillType = reader.Value;
                    break;

                case VBEle.bill_number:
                    reader.Read ();
                    vBill.bill.BillNumber = reader.Value;
                    break;

                case VBEle.billing_time:
                    reader.Read ();
                    // vBill.bill.BillTime = DateTime.Parse (reader.Value);
                    break;

                case VBEle.bill_amount:
                    reader.Read ();
                    vBill.bill.BillAmount = double.Parse (reader.Value);
                    break;

                case VBEle.bill_gross_amount:
                    reader.Read ();
                    vBill.bill.BillGrossAmount = double.Parse (reader.Value);
                    break;

                case VBEle.bill_discount:
                    reader.Read ();
                    vBill.bill.BillDiscount = double.Parse (reader.Value);
                    break;
            }
        }

        protected static void ReadEndElement()
        {
            Console.WriteLine ("End Tag :" + reader.Name);
        }

        protected static void ReadCustomer()
        {
            reader.Read ();
            ws.WriteLine ("Will Read Customer Name");
            ReadCustomer (reader.Name);
            reader.Read ();
            ws.WriteLine ("Will Read Mobile");
            ReadCustomer (reader.Name);
        }

        /// <summary>
        /// Read and Customer Info to Vbill 
        /// </summary>
        /// <param name="element">
        /// </param>
        protected static void ReadCustomer(string element)
        {
            ws.WriteLine ("Reading Customer:{0}", element);
            switch ( element )
            {
                case VBEle.customername:
                    reader.Read ();
                    vBill.bill.CustomerName = reader.Value;
                    ws.WriteLine ("CustName: {0}", reader.Value);
                    break;

                case VBEle.mobile:
                    reader.Read ();
                    vBill.bill.CustomerMobile = reader.Value;
                    ws.WriteLine ("Mobile:" + reader.Value);
                    break;
            }
            reader.Read ();// Read EndElement
        }

        protected static void ReadLineItems()
        {
            LineItems lItems = null;
            ws.WriteLine ("Reading Line Itmes ");
            int ids = 0;
            do
            {
                ws.Write ("One" + reader.Name);
                reader.Read ();

                ws.WriteLine ("two" + reader.Name);
                if ( reader.NodeType == XmlNodeType.Element )
                    switch ( reader.Name )
                    {
                        case VBEle.line_item:
                            lItems = new LineItems
                            {
                                ID = ++ids,
                                VoyBillId = -1
                            };
                            ws.WriteLine (" Line Item:{0},", ids);
                            break;

                        case VBEle.line_item_type:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.line_item_type = reader.Value;
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;

                        case VBEle.item_code:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.ItemCode = reader.Value;
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;

                        case VBEle.serial:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.Serial = Int32.Parse (reader.Value);
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;

                        case VBEle.value:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.Value = double.Parse (reader.Value);
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;

                        case VBEle.rate:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.Rate = double.Parse (reader.Value);
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;

                        case VBEle.qty:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.Qty = double.Parse (reader.Value);
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;

                        case VBEle.discount_value:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.DiscountValue = double.Parse (reader.Value);
                            ws.WriteLine (reader.Value);

                            reader.Read ();
                            break;

                        case VBEle.amount:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.Amount = double.Parse (reader.Value);
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;

                        case VBEle.description:
                            ws.Write (reader.Name + ": ");
                            reader.Read ();
                            lItems.Description = reader.Value;
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;
                    }
                else if ( reader.NodeType == XmlNodeType.EndElement )
                {
                    switch ( reader.Name )
                    {
                        case VBEle.line_item:
                            vBill.lineItems.Add (lItems);
                            ws.WriteLine ("LineItems {0} end.", ids);
                            break;

                        case VBEle.line_items:
                            ws.WriteLine ("LineItems Over");
                            break;
                    }
                }
            } while ( reader.Name == VBEle.line_items && reader.NodeType == XmlNodeType.EndElement );

        }

        protected static void ReadPayMode()
        {
            VPaymentMode vPay = null;
            ws.WriteLine ("Reading PayMode...");
            do
            {
                reader.Read ();
                if ( reader.NodeType == XmlNodeType.Element )
                {
                    switch ( reader.Name )
                    {
                        case VBEle.Payment_detail:
                            vPay = new VPaymentMode
                            {
                                ID = -1
                            };
                            ws.WriteLine ("Payment mode.");

                            break;
                        case VBEle.notes:
                            ws.Write (reader.Name + ":");

                            reader.Read ();
                            vPay.Notes = reader.Value;
                            ws.WriteLine (reader.Value);

                            reader.Read ();
                            break;
                        case VBEle.Payvalue:
                            ws.Write (reader.Name + ":");

                            reader.Read ();
                            vPay.Notes = reader.Value;
                            ws.WriteLine (reader.Value);

                            reader.Read ();
                            break;
                        case VBEle.mode:
                            ws.Write (reader.Name + ":");
                            reader.Read ();
                            vPay.Notes = reader.Value;
                            ws.WriteLine (reader.Value);
                            reader.Read ();
                            break;
                    }
                }
                else if ( reader.NodeType == XmlNodeType.EndElement )
                {
                    switch ( reader.Name )
                    {
                        case VBEle.payment:
                            vBill.payModes.Add (vPay);
                            break;
                    }
                }

            } while ( reader.Name == VBEle.Payment_Mode && reader.NodeType == XmlNodeType.EndElement );

        }
    }
}