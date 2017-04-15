using System;
using System.Data;
using System.Data.SqlClient;

namespace AprajitaRetails
{
    class AuthUser
    {
        public static string LoggedOn = "N/A";
        public static string LoggedTime = "00";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool CreateAuthUserTable(int mode)
        {
            bool status = false;
            string sql = "CREATE TABLE Users (Id INT NOT NULL," +
                "username varchar(50) NOT NULL,passwd varchar(20) NOT NULL,role INT NOT NULL, " +
                "CONSTRAINT unTb UNIQUE (Id));";
            Logs.LogMe ("CreateAuthUserTable:MODE: "+mode);

            DBHelper db = new DBHelper ();
            int ctr = 0;
            if ( mode == -1 )
            {
                ctr = db.InsertQuerySql (sql);
                Logs.LogMe ("TableCreated");
            }
            if ( mode == -2 )
            {
                ctr = 1;
            }
            if ( ctr > 0 )
            {
                Console.WriteLine ("Table Created");
                sql = "insert into users values(1,'admin','admin',1);";
                ctr = db.InsertQuerySql (sql);
                Logs.LogMe ("Defaults Added");
                if ( ctr > 0 )
                    status = true;
                else
                    status = false;
            }
            else
                status = false;
            db.CloseDB ();
            Console.WriteLine ("Ctr=" + ctr);

            return status;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int DoLogin(String username, String password)
        {
            if ( username == "" || password == "" )
                return -1;
            int status = 0;
            string sql = "select * from Users where username='" + username + "';";
            DBHelper db = new DBHelper ();
            SqlDataReader data = db.QueryStrSql (sql).ExecuteReader ();
            if ( data != null )
            {
                if ( data.Read () )
                {
                    String p = data.GetString (2);
                    //System.Windows.Forms.MessageBox.Show(p);
                    if ( p == password )
                        status = 1;
                    else
                        status = -1;
                }
                else
                    status = -1;

            }
            else
            {
                status = -1;
            }
            if ( status == 1 )
            { LoggedOn = username; LoggedTime = DateTime.Now.ToLocalTime ().ToString (); }
            db.CloseDB ();
            return status;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public int AddUser(String username, String password, String role)
        {

            if ( username != "" && password != "" && role != "" )
            {
                // System.Windows.Forms.MessageBox.Show(username+"/"+password+"/"+role);
                SqlConnection con = (SqlConnection) DataBase.GetConnectionObject (ConType.SQLDB);

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand ("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add (new SqlParameter ("@username", username));
                cmd.Parameters.Add (new SqlParameter ("@passwd", password));
                cmd.Parameters.Add (new SqlParameter ("@roles", role));
                //cmd.Connection = sqlConnection;
                int count = 0;
                try
                {
                    count = cmd.ExecuteNonQuery ();

                }
                catch ( Exception )
                {

                    //throw;
                    con.Close ();
                    // throw;
                    return -2;

                }
                //new DataBase(ConType.SQLDB).InsertStoreProcedure(cmd);
                con.Close ();
                return count;
            }
            else
                return -1;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="oldPaswword"></param>
        /// <param name="newPassword"></param>
        public void ChangePassword(String username, string oldPaswword, String newPassword)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void DeleteUser(String username, String password)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public static void BlockUser(String username)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public static void GetAllUser()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public static void GetRoles()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        public static int DoLogout(String Username)
        {
            LoggedOn = "N/A";
            LoggedTime = "00";
            // new LoginForm().Show();
            return 0;
        }
    }
}
