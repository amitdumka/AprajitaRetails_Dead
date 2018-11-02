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
    [Table( "PaySlip" )]
    public class PaySlip
    {//TODO: HRM database

        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int PaySlipID { get; set; }

        public String EmpCode { get; set; }

        public virtual EmpType EmpType { get; set; }
        public int EmpTypeID { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

        public int NoOfWorkingDay { get; set; }

        public int Attendence { get; set; }
        public int NoOfExtraWorkingDay { get; set; }


        public int Leaves { get; set; }
        public int NoofPaidLeave { get; set; }
        public int MedicalLeaves { get; set; }// AutoCalucalte it 
        public int CasualLeave { get; set; }// autoCalculate it

        public int SalaryID { get; set; }
        public virtual Salary Salary{get;set;}

        public double BasicSalary { get; set; }//Get from Salary table
        public double Incentive { get; set; }//Calculate it based on indiviual Sale

        public string StandDeducationDetails { get; set; } //Calculate it from Salary or payroll system
        public double StandardDeducation { get; set; }//calculate it from salary or payroll system

        public double NetSalary { get; set; } //auto calculate it based on data

        public double AspireBonus { get; set; } // Company bonus

        public string OtherDeducationsDetails { get; set; }// deduction of adv or other thing
        public double OtherDeducations { get; set; }// amount of deduction

        public double FinalPayment { get; set; } // Net Payment to be made
    }


}

