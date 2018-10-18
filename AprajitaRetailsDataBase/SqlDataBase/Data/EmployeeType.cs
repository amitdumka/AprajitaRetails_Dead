namespace AprajitaRetailsDataBase.SqlDataBase.Data
{
    public class EmployeeType
    {
        public static readonly int Accountant = 6;
        public static readonly int AssistanceManager = 3;
        public static readonly int HouseKeeping = 5;
        public static readonly int Others = 7;
        public static readonly int Owner = 1;
        public static readonly int SalesMan = 4;
        public static readonly int StoreManager = 2;

        public enum EmpType : int
        {
            Owner = 1,
            StoreManager = 2, AssistanceManager = 3, SalesMan = 4, HouseKeeping = 5,
            Accountant = 6, Others = 7
        }
    }
}