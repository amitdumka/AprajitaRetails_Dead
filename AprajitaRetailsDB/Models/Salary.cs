namespace AprajitaRetailsDB.Models.Data
{
    internal class Salary
    {
        public int ID { get; set; }
        public double BasicSalary { get; set; }
        public double ExtraSalary { get; set; }
        public Incentive IncentiveID { get; set; }
    }
}