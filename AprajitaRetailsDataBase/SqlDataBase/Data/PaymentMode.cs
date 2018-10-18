namespace AprajitaRetailsDataBase.SqlDataBase.Data
{
    /// <summary>
    /// TableName: PaymentMode
    /// </summary>
    public class PaymentMode
    {
        public int ID { get; set; }
        public string PayMode { get; set; }

        public override string ToString( )
        {
            return PayMode;
        }

        public static string GetPayModeName( int id )
        {
            string sMode = "Cash";
            switch (id)
            {
                case 7:
                    sMode = "Cash";
                    break;

                case 1:
                    sMode = "Cheque";
                    break;

                case 2:
                    sMode = "RTGS";
                    break;

                case 3:
                    sMode = "NEFT";
                    break;

                case 4:
                    sMode = "IMPS";
                    break;

                case 5:
                    sMode = "UPI";
                    break;

                case 6:
                    sMode = "PaymentApp";
                    break;

                case 8:
                    sMode = "BankTransfer";
                    break;

                case 9:
                    sMode = "Others";
                    break;

                default:
                    sMode = "Cash";
                    break;
            }
            return sMode;
        }

        public static int GetPayModeId( string name )
        {
            int sMode = 7;
            switch (name)
            {
                case "Cash":
                    sMode = 7;
                    break;

                case "Cheque":
                    sMode = 1;
                    break;

                case "RTGS":
                    sMode = 2;
                    break;

                case "NEFT":
                    sMode = 3;
                    break;

                case "IMPS":
                    sMode = 4;
                    break;

                case "UPI":
                    sMode = 5;
                    break;

                case "PaymentApp":
                    sMode = 6;
                    break;

                case "BankTransfer":
                    sMode = 8;
                    break;

                case "Others":
                    sMode = 9;
                    break;

                default:
                    sMode = 7;
                    break;
            }
            return sMode;
        }
    }
}