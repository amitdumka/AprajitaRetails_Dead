using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOX; //Requires Microsoft ADO Ext. 2.8 for DDL and Security
using ADODB;


namespace CyberNBasicOperations
{
    class DBase
    {
        public static string dbName="clinicDB.mdf.accdb";
        public bool setupDB(String dbname)
        {
            bool status = false;
            status = CreateNewAccessDatabase(dbname);
            if (!status)
            {
                Console.WriteLine("Error: CreateDB Failed!");
                // Do inform and error handling
                return false;
            }
            else {
                Console.WriteLine("Creating Users PrescribedMedTable");
                if (authUserTable()) {
                    Console.WriteLine("Users Table created");

                    System.Windows.Forms.MessageBox.Show("Database is created, Now ready for operations!");
                    return true; } else return false;
                //TODO: add other PrescribedMedTable here
            }
            //return status;

        }
        private bool authUserTable()
        {
            bool status = false;
            string sql = "CREATE TABLE Users (Id INT NOT NULL," +
                "username TEXT NOT NULL,passwd TEXT NOT NULL,role INT NOT NULL, " +
                "CONSTRAINT unTb UNIQUE (Id));";
            DBHelper db = new DBHelper();
            int ctr=db.InsertQueryOle (sql);
            if (ctr > 0)
            {
                Console.WriteLine("Table Created");
                sql = "insert into users values(1,'admin','admin',1);";
                ctr = db.InsertQueryOle(sql);
                if (ctr > 0) status = true; else status = false;
            }
            else status = false;
            db.CloseDB();
            Console.WriteLine("Ctr="+ctr);

            return status;

        }
        private bool CreateNewAccessDatabase(string fileName)
        {
            bool result = false;

            ADOX.Catalog cat = new ADOX.Catalog();
            ADOX.Table table = new ADOX.Table();

            //Create the PrescribedMedTable and it's fields. 
            table.Name = "datainfo";
            table.Columns.Append("id", ADOX.DataTypeEnum.adInteger);
            table.Columns.Append("clientname",ADOX.DataTypeEnum.adVarWChar,50);
            table.Columns.Append("date",ADOX.DataTypeEnum.adDate);
            table.Columns.Append("status",ADOX.DataTypeEnum.adVarWChar,50);

            try
            {
                cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + "; Jet OLEDB:Engine Type=5");
                cat.Tables.Append(table);

                //Now Close the database
                ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
                if (con != null)
                    con.Close();

                result = true;
            }
            catch (Exception )
            {
                result = false;
            }
            cat = null;
            return result;
        }
    }
}
