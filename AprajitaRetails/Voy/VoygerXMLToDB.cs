using AprajitaRetails.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AprajitaRetails.Voy
{
    internal class VoygerXMLToDB
    {
        private DataTable vbTable;
        private static Clients client = CurrentClient.LoggedClient;

        public VoygerXMLToDB( )
        {
            vbTable = new DataTable("VoyBill");
        }
    }

    public class VoygerBill
    {
        public VoyBill bill;
        public List<VPaymentMode> payModes;
        public List<LineItems> lineItems;

        public VoygerBill( )
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
        private static VoygerBill vBill;

        // private static XmlTextReader reader;
        private static StreamWriter fileWR;

        public static void WriteVoyDataToFile( )
        {//TODO: no use
            if (fileWR == null)
            {
                fileWR = File.AppendText("d:\\DataSet.txt"); //TODO: remove it
                fileWR.WriteLine("xml:{0}: Using DataSet:");
            }
            fileWR.WriteLine("Dumping VBill Object Data to File.");
            fileWR.WriteLine();
            fileWR.WriteLine(ObjectDumper.Dump(vBill));
        }

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

        /// <summary>
        /// read invoicexml
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static VoygerBill ReadInvoiceXML( string filename )
        {
            DataSet dataSet = ReadXML(filename);

            if (dataSet != null || dataSet.Tables.Count > 0)
            {
                vBill = new VoygerBill();
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
                vBill = new VoygerBill();
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

            WriteVoyDataToFile();
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
            vBill.bill.ID = -1;
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

    public class ObjectDumper
    {
        private int _level;
        private readonly int _indentSize;
        private readonly StringBuilder _stringBuilder;
        private readonly List<int> _hashListOfFoundElements;

        private ObjectDumper( int indentSize )
        {
            _indentSize = indentSize;
            _stringBuilder = new StringBuilder();
            _hashListOfFoundElements = new List<int>();
        }

        public static string Dump( object element )
        {
            return Dump(element, 2);
        }

        public static string Dump( object element, int indentSize )
        {
            var instance = new ObjectDumper(indentSize);
            return instance.DumpElement(element);
        }

        private string DumpElement( object element )
        {
            if (element == null || element is ValueType || element is string)
            {
                Write(FormatValue(element));
            }
            else
            {
                var objectType = element.GetType();
                if (!typeof(IEnumerable).IsAssignableFrom(objectType))
                {
                    Write("{{{0}}}", objectType.FullName);
                    _hashListOfFoundElements.Add(element.GetHashCode());
                    _level++;
                }

                var enumerableElement = element as IEnumerable;
                if (enumerableElement != null)
                {
                    foreach (object item in enumerableElement)
                    {
                        if (item is IEnumerable && !(item is string))
                        {
                            _level++;
                            DumpElement(item);
                            _level--;
                        }
                        else
                        {
                            if (!AlreadyTouched(item))
                                DumpElement(item);
                            else
                                Write("{{{0}}} <-- bidirectional reference found", item.GetType().FullName);
                        }
                    }
                }
                else
                {
                    MemberInfo[] members = element.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
                    foreach (var memberInfo in members)
                    {
                        var fieldInfo = memberInfo as FieldInfo;
                        var propertyInfo = memberInfo as PropertyInfo;

                        if (fieldInfo == null && propertyInfo == null)
                            continue;

                        var type = fieldInfo != null ? fieldInfo.FieldType : propertyInfo.PropertyType;
                        object value = fieldInfo != null
                                           ? fieldInfo.GetValue(element)
                                           : propertyInfo.GetValue(element, null);

                        if (type.IsValueType || type == typeof(string))
                        {
                            Write("{0}: {1}", memberInfo.Name, FormatValue(value));
                        }
                        else
                        {
                            var isEnumerable = typeof(IEnumerable).IsAssignableFrom(type);
                            Write("{0}: {1}", memberInfo.Name, isEnumerable ? "..." : "{ }");

                            var alreadyTouched = !isEnumerable && AlreadyTouched(value);
                            _level++;
                            if (!alreadyTouched)
                                DumpElement(value);
                            else
                                Write("{{{0}}} <-- bidirectional reference found", value.GetType().FullName);
                            _level--;
                        }
                    }
                }

                if (!typeof(IEnumerable).IsAssignableFrom(objectType))
                {
                    _level--;
                }
            }

            return _stringBuilder.ToString();
        }

        private bool AlreadyTouched( object value )
        {
            if (value == null)
                return false;

            var hash = value.GetHashCode();
            for (var i = 0; i < _hashListOfFoundElements.Count; i++)
            {
                if (_hashListOfFoundElements[i] == hash)
                    return true;
            }
            return false;
        }

        private void Write( string value, params object[] args )
        {
            var space = new string(' ', _level * _indentSize);

            if (args != null)
                value = string.Format(value, args);

            _stringBuilder.AppendLine(space + value);
        }

        private string FormatValue( object o )
        {
            if (o == null)
                return ("null");

            if (o is DateTime)
                return (((DateTime)o).ToShortDateString());

            if (o is string)
                return string.Format("\"{0}\"", o);

            if (o is char && (char)o == '\0')
                return string.Empty;

            if (o is ValueType)
                return (o.ToString());

            if (o is IEnumerable)
                return ("...");

            return ("{ }");
        }
    }
}