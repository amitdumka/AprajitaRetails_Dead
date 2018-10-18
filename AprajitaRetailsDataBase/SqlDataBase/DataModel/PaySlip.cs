using AprajitaRetailsDataBase.SqlDataBase.Data;

namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{
    internal class PaySlip
    {
        public int ID { get; set; }
        public int EmpCode { get; set; }
        public EmployeeType EmpTyee { get; set; }
        public int NoOfWorkingDay { get; set; }
        public int Attendence { get; set; }
        public int Leaves { get; set; }
        public int NoofPaidLeave { get; set; }
        public int MedicalLeaves { get; set; }
        public int CasualLeave { get; set; }
        public Salary SalaryID { get; set; }
        public double BasicSalary { get; set; }
        public double Incentive { get; set; }
        public string StandDeducationDetails { get; set; }
        public double StandardDeducation { get; set; }
        public double NetSalary { get; set; }
        public double AspireBonus { get; set; }
        public string OtherDeducationsDetails { get; set; }
        public double OtherDeducations { get; set; }
        public double FinalPayment { get; set; }
    }
}