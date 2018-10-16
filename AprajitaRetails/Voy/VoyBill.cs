using AprajitaRetails.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetails.Voy
{
    public enum BillType { SA, Regular, SaleReturn }

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

    public class VCustomer
    {
        // TODO: Check for better apporch in futures
        public int ID { get; set; }

        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
    }

    public class VoyBill
    {
        public int ID { get; set; }
        public string BillType { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillTime { get; set; }
        public double BillAmount { get; set; }
        public double BillGrossAmount { get; set; }
        public double BillDiscount { get; set; }
        public string CustomerName { get; set; } //VCustomer
        public string CustomerMobile { get; set; }//VCustomer
        public string StoreID { get; set; }
    }

    public class LineItems
    {
        public int ID { get; set; }
        public int VoyBillId { get; set; } //FK
        public string LineType { get; set; }//<line_item_type>
        public int Serial { get; set; }//<serial>
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }
        public double Value { get; set; }
        public double DiscountValue { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        //TODO: Store basic info . rest take from database in future
    }

    public class VPaymentMode
    {
        public int ID { get; set; }
        public int VoyBillId { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentValue { get; set; }
        public string Notes { get; set; }
    }

    public class VoyBillDm : DataOps<VoyBill>
    {
        public override int InsertData( VoyBill obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            //Parameters
            cmd.Parameters.AddWithValue("@BillAmount", obj.BillAmount);
            cmd.Parameters.AddWithValue("@BillDiscount", obj.BillDiscount);
            cmd.Parameters.AddWithValue("@BillGrossAmount", obj.BillGrossAmount);
            cmd.Parameters.AddWithValue("@BillNumber", obj.BillNumber);
            cmd.Parameters.AddWithValue("@BillTime", obj.BillTime);
            cmd.Parameters.AddWithValue("@BillType", obj.BillType);
            cmd.Parameters.AddWithValue("@CustomerMobile", obj.CustomerMobile);
            cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            cmd.Parameters.AddWithValue("@StoreID", obj.StoreID);
            return cmd.ExecuteNonQuery();
        }

        public override VoyBill ResultToObject( List<VoyBill> data, int index )
        {
            return data[index];
        }

        public override VoyBill ResultToObject( SortedDictionary<string, string> item )
        {
            return new VoyBill()
            {
                ID = Basic.ToInt(item["ID"]),
                StoreID = item["StoreID"],
                CustomerName = item["CustomerName"],
                BillAmount = Basic.ToDouble(item["BillAmount"]),
                BillDiscount = Basic.ToDouble(item["BillDiscount"]),
                BillTime = DateTime.Parse(item["BillTime"]),
                BillGrossAmount = Basic.ToDouble(item["BillGrossAmount"]),
                BillNumber = item["BillNumber"],
                BillType = item["BillType"],
                CustomerMobile = item["CustomerMobile"]
            };
        }

        public override List<VoyBill> ResultToObject( List<SortedDictionary<string, string>> data )
        {
            List<VoyBill> list = new List<VoyBill>();
            VoyBill att;
            foreach (SortedDictionary<string, string> item in data)
            {
                att = new VoyBill()
                {
                    ID = Basic.ToInt(item["ID"]),
                    StoreID = item["StoreID"],
                    CustomerName = item["CustomerName"],
                    BillAmount = Basic.ToDouble(item["BillAmount"]),
                    BillDiscount = Basic.ToDouble(item["BillDiscount"]),
                    BillTime = DateTime.Parse(item["BillTime"]),
                    BillGrossAmount = Basic.ToDouble(item["BillGrossAmount"]),
                    BillNumber = item["BillNumber"],
                    BillType = item["BillType"],
                    CustomerMobile = item["CustomerMobile"]
                };
                list.Add(att);
            }
            return list;
        }

        public static bool Insert( List<VoyBill> datas, string table )
        {
            //TODO: This system is also gud can be used for future if prolem arise or keep in Lib
            bool result = false;
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();

            SqlConnection con = new SqlConnection("your connection string");
            con.Open();

            try
            {
                foreach (var data in datas)
                {
                    values.Clear();
                    foreach (var item in data.GetType().GetProperties())
                    {
                        values.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                    }

                    string xQry = GetInsertCommand(table, values);
                    SqlCommand cmdi = new SqlCommand(xQry, con);
                    cmdi.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception ex)
            { throw ex; }
            finally { con.Close(); }
            return result;
        }

        private static string GetInsertCommand( string table, List<KeyValuePair<string, string>> values )
        {
            //TODO: This system is also gud can be used for future if prolem arise or keep in Lib

            string query = null;
            query += "INSERT INTO " + table + " ( ";
            foreach (var item in values)
            {
                query += item.Key;
                query += ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += ") VALUES ( ";
            foreach (var item in values)
            {
                if (item.Key.GetType().Name == "System.Int") // or any other numerics
                {
                    query += item.Value;
                }
                else
                {
                    query += "'";
                    query += item.Value;
                    query += "'";
                }
                query += ", ";
            }
            query = query.Remove(query.Length - 2, 2);
            query += ")";
            return query;
        }
    }
}