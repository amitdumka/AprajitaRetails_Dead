using AprajitaRetails.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AprajitaRetails.ViewModel
{
    internal class AttendenceVM
    {
        private AttendenceDM aDM = new AttendenceDM();

        public List<string> GetAllEmpCodes( )
        {
            return aDM.GetEmpCodes();
        }

        public List<string> GetEmpName( string empCode )
        {
            return aDM.GetEmpName(empCode);
        }

        public int SaveData( Attendence attendence )
        {
            return aDM.InsertData(attendence);
        }
    }

    internal class AttendenceDM : DataOps<Attendence>
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public List<string> GetEmpCodes( )
        {
            List<string> empCode = new List<string>();
            string sql = "Select EMPCode from Employee";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            empCode = DataBase.GetQueryString(cmd, "EMPCode");
            return empCode;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="empCode"></param>
        /// <returns></returns>
        public List<string> GetEmpName( string empCode )
        {
            List<string> emp = new List<string>();
            string sql = "select FirstName, LastName from Employee where EMPCode=@empCode";
            SqlCommand cmd = new SqlCommand(sql, Db.DBCon);
            cmd.Parameters.AddWithValue("@empCode", empCode);
            SqlDataReader result = cmd.ExecuteReader();
            if (result != null)
            {
                if (result.HasRows)
                {
                    result.Read();
                    emp.Add((string)result.GetValue(0));
                    emp.Add((string)result.GetValue(1));
                }
            }
            result.Close();
            return emp;
        }

        public override int InsertData( Attendence obj )
        {
            SqlCommand cmd = new SqlCommand(InsertSqlQuery, Db.DBCon);
            //Parameters
            cmd.Parameters.AddWithValue("@AttendenceNo", obj.AttendenceNo);
            cmd.Parameters.AddWithValue("@EMPCode", obj.EMPCode);
            cmd.Parameters.AddWithValue("@IsAbesent", obj.IsAbesent);
            cmd.Parameters.AddWithValue("@IsPaidLeave", obj.IsPaidLeave);
            cmd.Parameters.AddWithValue("@OnDate", obj.OnDate);

            return cmd.ExecuteNonQuery();
        }

        public override Attendence ResultToObject( List<Attendence> data, int index )
        {
            return data[index];
        }

        public override Attendence ResultToObject( SortedDictionary<string, string> item )
        {
            return new Attendence()
            {
                ID = Basic.ToInt(item["ID"]),
                AttendenceNo = Basic.ToInt(item["AttendenceNo"]),
                EMPCode = item["EMPCode"],
                IsAbesent = Basic.ToInt(item["IsAbesent"]),
                IsPaidLeave = Basic.ToInt(item["IsPaidLeave"]),
                OnDate = DateTime.Parse(item["OnDate"])
            };
        }

        public override List<Attendence> ResultToObject( List<SortedDictionary<string, string>> data )
        {
            List<Attendence> list = new List<Attendence>();
            Attendence att;
            foreach (SortedDictionary<string, string> item in data)
            {
                att = new Attendence()
                {
                    ID = Basic.ToInt(item["ID"]),
                    AttendenceNo = Basic.ToInt(item["AttendenceNo"]),
                    EMPCode = item["EMPCode"],
                    IsAbesent = Basic.ToInt(item["IsAbesent"]),
                    IsPaidLeave = Basic.ToInt(item["IsPaidLeave"]),
                    OnDate = DateTime.Parse(item["OnDate"])
                };
                list.Add(att);
            }
            return list;
        }
    }
}