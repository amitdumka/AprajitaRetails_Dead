namespace AprajitaRetailsDataBase.SqlDataBase.DataModel
{
    /// <summary>
    /// Table Name: ExpensesForm
    /// </summary>
    internal class ExpensesDM
    {
        public int ID { get; set; }
        public int ExpensesCategoryID { get; set; }
        public string ExpensesReason { get; set; }
        public string ApprovedBy { get; set; }
        public int PaymentModeID { get; set; }
        public double Amount { get; set; }
        public int BankDetailsID { get; set; }
        //TODO: Scope of update in future based on Usage
    }
}