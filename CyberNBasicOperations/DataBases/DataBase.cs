using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CyberNBasicOperations
{
    class DataBase : IDisposable
    {
        DBHelper db;
        public static int DBType = 1;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                db.Dispose();
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DataBase(int type)
        {
            db = new DBHelper();
            DBType = type;
        }
        public void ConnnetDB()
        {
            db.ConnectDB(DBType);

        }
        public void Querry(String sql)
        {
            if (DBType == DBHelper.SQLDB)
            {
                db.QueryStrSql(sql);
            }
            if (DBType == DBHelper.OLEDB)
            {
                db.QueryStrSql(sql);
            }

        }
        public int Insert(String sql)
        {
            if (DBType == DBHelper.SQLDB)
            {
                return db.InsertQuerySql(sql);

            }
            if (DBType == DBHelper.OLEDB)
            {
                return db.InsertQueryOle(sql);
            }
            return -1;
        }
        public int Delete(String sql)
        {
            if (DBType == DBHelper.SQLDB)
            {
                return db.NonQuerySql(sql);
            }
            if (DBType == DBHelper.OLEDB)
            {
                return db.NonQueryOle(sql);
            }
            return -1;
        }
        public int Update(String sql)
        {
            if (DBType == DBHelper.SQLDB)
            {
                return db.NonQuerySql(sql);
            }
            if (DBType == DBHelper.OLEDB)
            {
                return db.NonQueryOle(sql);
            }
            return -1;

        }
        public void CloseDB()
        {
            if (DBType == DBHelper.SQLDB)
            {
                db.CloseDB();
            }
            if (DBType == DBHelper.OLEDB)
            {
                db.CloseDB();
            }

        }
        public int InsertStoreProcedure(System.Data.SqlClient.SqlCommand cmd)
        {
            SqlConnection con = (SqlConnection)GetConnectionObject(DBHelper.SQLDB);
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            try
            {
                count = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return count;

        }

        public int InsertStoreProcedure(System.Data.OleDb.OleDbCommand cmd)
        {
            OleDbConnection con = (OleDbConnection)GetConnectionObject(DBHelper.OLEDB);
            cmd.Connection = con;
            int count = 0;
            try
            {
                count = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return count;


        }

        public static Object GetConnectionObject(int type)
        {
            return new DBHelper().GetConnectioObject(type);
        }

        public static int GetSqlStoreProcedureReturnInt(SqlCommand cmd)
        {
            SqlConnection con = (SqlConnection)GetConnectionObject(DBHelper.SQLDB);
            cmd.Connection = con;
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            int ctr= cmd.ExecuteNonQuery();
            var result = returnParameter.Value;
            con.Close();
            return Int32.Parse("" + result);

        }
        public static List<string> GetSqlStoreProcedureString(string sp, string colName)
        {
            SqlConnection con = (SqlConnection)GetConnectionObject(DBHelper.SQLDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sp;
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            List<string> data = new List<string>(); ;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data.Add((string)reader[colName]);
                    count++;
                }
            }
            catch (Exception ex)
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }
            return data;
        }

        public static List<int> GetSqlStoreProcedureInt(String storeProc, string colName)
        {
            SqlConnection con = (SqlConnection)GetConnectionObject(DBHelper.SQLDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = storeProc;
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            List<int> data = new List<int>(); ;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data.Add((int)reader[colName]);
                    count++;
                }
            }
            catch (Exception ex)
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }
            return data;
        }
        public static List<SortedDictionary<string,string >> GetSqlStoreProcedureString(string sp)
        {
            SqlConnection con = (SqlConnection)GetConnectionObject(DBHelper.SQLDB);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sp;
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            List<SortedDictionary<string, string>> data = new List<SortedDictionary<string, string>>(); ;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int noOfField=reader.FieldCount;
                    SortedDictionary<string, string> sdData = new SortedDictionary<string, string>();
                    for (int j = 0; j < noOfField; j++)
                    {
                        sdData.Add(reader.GetName(j), (string)reader.GetValue(j));
                        
                    }
                    data.Add(sdData);
                    count++;

                }
            }
            catch (Exception ex)
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }
            return data;
        }

        public static List<SortedDictionary<string, string>> GetSqlStoreProcedureString(SqlCommand cmd)
        {
            SqlConnection con = (SqlConnection)GetConnectionObject(DBHelper.SQLDB);
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = sp;
            cmd.Connection = con;
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            int count = 0;
            List<SortedDictionary<string, string>> data = new List<SortedDictionary<string, string>>(); ;
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int noOfField = reader.FieldCount;
                    SortedDictionary<string, string> sdData = new SortedDictionary<string, string>();
                    for (int j = 0; j < noOfField; j++)
                    {
                        sdData.Add(reader.GetName(j), ""+reader.GetValue(j));

                    }
                    data.Add(sdData);
                    count++;

                }
            }
            catch (Exception ex)
            {
                count = -2;
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }
            return data;
        }

    }

}


