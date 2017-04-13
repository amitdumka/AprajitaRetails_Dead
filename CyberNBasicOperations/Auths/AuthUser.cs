using System;
//using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace CyberNBasicOperations
{
    class AuthUser
    {
        public static string LoggedOn="N/A";
        public static string LoggedTime = "00";

        public static  int DoLogin(String username, String password)
        {
            if (username == "" || password == "") return -1;
            int status = 0;
            string sql = "select * from Users where username='" + username + "';";
            DBHelper db = new DBHelper();
            OleDbDataReader data= db.QueryStrOle(sql).ExecuteReader();
            if (data != null)
            {
                if (data.Read()) { 
                String p = data.GetString(2);
                //System.Windows.Forms.MessageBox.Show(p);
                if (p == password)
                        status = 1;
                else
                        status = -1;
                }
                else status= - 1;

            }
            else {
                status = -1;
            }
            if (status == 1) { LoggedOn = username; LoggedTime = DateTime.Now.ToLocalTime().ToString(); }
            db.CloseDB();
            return status;
        }
        public int AddUser(String username, String password, String role)
        {

            if (username != "" && password != "" && role != "") {
               // System.Windows.Forms.MessageBox.Show(username+"/"+password+"/"+role);
                SqlConnection con = (SqlConnection)DataBase.GetConnectionObject(DBHelper.SQLDB);

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("AddUser",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@passwd", password));
                cmd.Parameters.Add(new SqlParameter("@roles", role));
                //cmd.Connection = sqlConnection;
                int count = 0;
                try
                {
                     count = cmd.ExecuteNonQuery();

                }
                catch (Exception)
                {

                    //throw;
                    con.Close();
                   // throw;
                    return -2;

                }
                //new DataBase(DBHelper.SQLDB).InsertStoreProcedure(cmd);
                con.Close();
                return count;
            }
            else
            return -1;
            

        }
        public void ChangePassword (String username, string oldPaswword, String newPassword)
        {

        }
        public void DeleteUser(String username, String password)
        {

        }

        public static void BlockUser(String username) {
        }

        public static void GetAllUser() {
        }
        public static void GetRoles() {
        }
        public static int DoLogout(String Username) {
            LoggedOn = "N/A";
            LoggedTime = "00";
           // new LoginForm().Show();
            return 0;
        }
    }
}
