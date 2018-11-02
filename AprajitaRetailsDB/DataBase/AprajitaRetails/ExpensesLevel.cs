using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using AprajitaRetailsDB.DataBase.AprajitaRetails.HRM;

namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    /// <summary>
    /// ExpensesForm Level
    /// </summary>
    public class ExpensesLevel
    {
        public static readonly int General = 1;
        public static readonly int Low = 2;
        public static readonly int Medium = 3;
        public static readonly int High = 4;
        public static readonly int VeryHigh = 5;
        public static readonly int Other = 6;

        public static int ExpensesLevelID( string level )
        {
            int id = 1;
            switch (level)
            {
                case "Other":
                    id=6;
                    break;

                case "VeryHigh":
                    id=5;
                    break;

                case "High":
                    id=4;
                    break;

                case "General":
                    id=1;
                    break;

                case "Low":
                    id=2;
                    break;

                case "Medium":
                    id=3;
                    break;

                default:
                    id=1;
                    break;
            }

            return id;
        }

        public static string ExpensesLevelName( int id )
        {
            string name = "General";
            switch (id)
            {
                case 6:
                    name="Other";
                    break;

                case 5:
                    name="VeryHigh";
                    break;

                case 4:
                    name="High";
                    break;

                case 1:
                    name="General";
                    break;

                case 2:
                    name="Low";
                    break;

                case 3:
                    name="Medium";

                    break;

                default:
                    name="General";
                    break;
            }
            return name;
        }
    }


}

