using CyberN.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public class ProductItemsDB : DataOps<ProductItems>
    {
        public List<string> GetBarCodeList( int x )
        {
            string sql = "select BarCode from " + this.Tablename + " where  Size = '44'";
            //select* from ProductItems where Size = '44'
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return DataBase.GetQueryString(cmd, "BarCode");
        }

        public List<string> GetItemsList( )
        {
            string sql = "select StyleCode from " + this.Tablename;
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return DataBase.GetQueryString(cmd, "StyleCode");
        }

        public List<string> GetItemsList( string condition, string value )
        {
            string sql = "select StyleCode from " + this.Tablename +
                         " where " + condition + "=@value";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@value", value);
            return DataBase.GetQueryString(cmd, "StyleCode");
        }

        public ProductItems GetProductItemDetais( string barcode )
        {
            return this.GetByColName("Barcode", barcode);
        }

        public ProductItems GetProductItemByStyle( string styleCode )
        {
            return this.GetByColName("StyleCode", styleCode);
        }

        public bool IsStyleCodeExist( string styleCode )
        {
            string sql = "select Count(StyleCode) from " + Tablename + " where StyleCode=@code";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@code", styleCode);
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
                return true;
            else
                return false;
        }

        public double GetQty( string styleCode )
        {
            string sql = "select Qty from " + Tablename + " where StyleCode=@code";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@code", styleCode);

            object count = cmd.ExecuteScalar();
            Console.WriteLine("Qty={0}", count);
            double c = double.Parse("" + count);
            return c;
        }

        public int UpdateQty( string styleCode, double qty, int mode )
        {
            double fQty = 0;
            double pQty = GetQty(styleCode);
            if (mode == 0)
                fQty = pQty + qty;
            else if (mode == 1)
                fQty = pQty - qty;
            string sql = "Update " + Tablename + " set Qty=" + fQty + "where StyleCode='" + styleCode + "'";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            return cmd.ExecuteNonQuery();
        }

        public int InsertDataWithVerify( ProductItems obj )
        {
            if (IsStyleCodeExist(obj.StyleCode))
            {
                //Add Qty
                return UpdateQty(obj.StyleCode, obj.Qty, 0);
            }
            else
            {
                return InsertData(obj);
            }
        }

        public override int InsertData( ProductItems obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            cmd.Parameters.AddWithValue("@Barcode", obj.Barcode);
            cmd.Parameters.AddWithValue("@BrandName", obj.BrandName);
            cmd.Parameters.AddWithValue("@Cost", obj.Cost);
            cmd.Parameters.AddWithValue("@ItemDesc", obj.ItemDesc);
            cmd.Parameters.AddWithValue("@MRP", obj.MRP);
            cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
            cmd.Parameters.AddWithValue("@Qty", obj.Qty);
            cmd.Parameters.AddWithValue("@Size", obj.Size);
            cmd.Parameters.AddWithValue("@StyleCode", obj.StyleCode);
            cmd.Parameters.AddWithValue("@SupplierId", obj.SupplierId);
            cmd.Parameters.AddWithValue("@Tax", obj.Tax);

            //GST Implementation
            /* cmd.Parameters.AddWithValue ("@CGST", obj.CGST);
             cmd.Parameters.AddWithValue ("@SGST", obj.SGST);
             cmd.Parameters.AddWithValue ("@IGST", obj.IGST);
             cmd.Parameters.AddWithValue ("@PreGST", obj.PreGST);
             cmd.Parameters.AddWithValue ("@HSNCode", obj.HSNCode);
              */
            return cmd.ExecuteNonQuery();
        }

        public override ProductItems ResultToObject( List<ProductItems> data, int index )
        {
            return data[index];
        }

        public override ProductItems ResultToObject( SortedDictionary<string, string> data )
        {
            if (data == null)
                return null;
            ProductItems pItem = new ProductItems()
            {
                ID = Basic.ToInt(data["ID"]),
                Tax = double.Parse(data["Tax"]),
                SupplierId = data["SupplierId"],
                StyleCode = data["StyleCode"],
                Size = data["Size"],
                Qty = double.Parse(data["Qty"]),
                Barcode = data["Barcode"],
                BrandName = data["BrandName"],
                Cost = double.Parse(data["Cost"]),
                ItemDesc = data["ItemDesc"],
                MRP = double.Parse(data["MRP"]),
                ProductName = data["ProductName"]
                /* CGST = double.Parse (data ["CGST"]),
                 HSNCode = double.Parse (data ["HSNCode"]),
                 IGST = double.Parse (data ["IGST"]),
                 SGST = double.Parse (data ["SGST"]),
                 PreGST = Int32.Parse (data ["PreGST"])*/
            };
            return pItem;
        }

        public override List<ProductItems> ResultToObject( List<SortedDictionary<string, string>> dataList )
        {
            List<ProductItems> listItem = new List<ProductItems>();
            foreach (var data in dataList)
            {
                ProductItems pItem = new ProductItems()
                {
                    ID = Basic.ToInt(data["ID"]),
                    Tax = double.Parse(data["Tax"]),
                    SupplierId = data["SupploerId"],
                    StyleCode = data["StyleCode"],
                    Size = data["Size"],
                    Qty = double.Parse(data["Qty"]),
                    Barcode = data["Barcode"],
                    BrandName = data["BrandName"],
                    Cost = double.Parse(data["Cost"]),
                    ItemDesc = data["ItemDesc"],
                    MRP = double.Parse(data["MRP"]),
                    ProductName = data["ProductName"]/*,
                    CGST = double.Parse (data ["CGST"]),
                    HSNCode = double.Parse (data ["HSNCode"]),
                    IGST = double.Parse (data ["IGST"]),
                    SGST = double.Parse (data ["SGST"]),
                    PreGST = Int32.Parse (data ["PreGST"])*/
                };
                listItem.Add(pItem);
            }
            return listItem;
        }
    }
}