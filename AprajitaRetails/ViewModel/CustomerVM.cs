using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AprajitaRetails.Data;

namespace AprajitaRetails.ViewModel
{
    public class CustomerVM
    {
        public void AddData()
        {

        }
        public int SaveData(Customer cust)
        {
            return DB.InsertData (cust);
        }
        CustomerDB DB;
        public CustomerVM()
        {
            DB = new CustomerDB ();
        }
    }
}
