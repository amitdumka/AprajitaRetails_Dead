using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AprajitaRetailsDataBase
{
    //[global::System.Data.Linq.Mapping.DatabaseAttribute(Name = "aprajitaretails")]

    [Database(Name = "TASVoyger")]
    public class TASVoyger : DataContext
    {
        public TASVoyger( string con ) : base(con)
        {
            if (!DatabaseExists())
                CreateDatabase();
        }

        public Table<VoyBill> VoyBills;
        public Table<VPaymentMode> VPaymentModes;
        public Table<LineItems> LineItem;
    }

    [Table(Name = "VoyBill")]
    public class VoyBill
    {
        public int _ID;
        public string _BillType;
        public string _BillNumber;
        public DateTime _BillTime;
        public double _BillAmount;
        public double _BillGrossAmount;
        public double _BillDiscount;
        public string _CustomerName; //VCustomer
        public string _CustomerMobile;//VCustomer
        public string _StoreID;

        [Column(Storage = "_ID", AutoSync = AutoSync.Always, DbType = "int not null", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; }

        [Column(Storage = "_BillType")]
        public string BillType { get; set; }

        [Column(Storage = "_BillNuber")]
        public string BillNumber { get; set; }

        [Column(Storage = "_BillTime")]
        public DateTime BillTime { get; set; }

        [Column(Storage = "_BillAmount")]
        public double BillAmount { get; set; }

        [Column(Storage = "_BillGrossAmount")]
        public double BillGrossAmount { get; set; }

        [Column(Storage = "_BillDiscount")]
        public double BillDiscount { get; set; }

        [Column(Storage = "_CustomerName")]
        public string CustomerName { get; set; } //VCustomer

        [Column(Storage = "_CustomerMobile")]
        public string CustomerMobile { get; set; }//VCustomer

        [Column(Storage = "_StoreID")]
        public string StoreID { get; set; }

        private EntitySet<LineItems> _lineItems;

        [Association(Storage = "_lineItems", OtherKey = "ID")]
        public EntitySet<LineItems> LineItem
        {
            get { return this._lineItems; }
            set { this._lineItems.Assign(value); }
        }

        private EntitySet<VPaymentMode> _VPaymentModes;

        [Association(Storage = "_VPaymentModes", OtherKey = "ID")]
        public EntitySet<VPaymentMode> VPaymentModes
        {
            get { return this._VPaymentModes; }
            set { this._VPaymentModes.Assign(value); }
        }

        public VoyBill( )
        {
            this._VPaymentModes = new EntitySet<VPaymentMode>();
            this._lineItems = new EntitySet<LineItems>();
        }
    }

    [Table(Name = "LineItems")]
    public class LineItems
    {
        public int _ID;
        public int _VoyBillId; //FK
        public string _LineType;//<line_item_type>
        public int _Serial;//<serial>
        public string _ItemCode;
        public double _Qty;
        public double _Rate;
        public double _Value;
        public double _DiscountValue;
        public double _Amount;
        public string _Description;

        [Column(Storage = "_ID", AutoSync = AutoSync.Always, DbType = "int not null", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column]
        public int VoyBillId { get; set; } //FK

        [Column]
        public string LineType { get; set; }//<line_item_type>

        [Column]
        public int Serial { get; set; }//<serial>

        [Column]
        public string ItemCode { get; set; }

        [Column]
        public double Qty { get; set; }

        [Column]
        public double Rate { get; set; }

        [Column]
        public double Value { get; set; }

        [Column]
        public double DiscountValue { get; set; }

        [Column]
        public double Amount { get; set; }

        [Column]
        public string Description { get; set; }

        private EntityRef<VoyBill> _voyBill;

        [Association(Storage = "_voyBill", ThisKey = "VoyBillId")]
        public VoyBill VoyBills
        {
            get { return this._voyBill.Entity; }
            set { this._voyBill.Entity = value; }
        }

        public LineItems( )
        {
            this._voyBill = new EntityRef<VoyBill>();
        }

        //TODO: Store basic info . rest take from database in future
    }

    [Table(Name = "VPaymentMode")]
    public class VPaymentMode
    {
        public int _ID;
        public int _VoyBillId;
        public string _PaymentMode;
        public string _PaymentValue;
        public string _Notes;

        [Column(Storage = "_ID", AutoSync = AutoSync.Always, DbType = "int not null", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        [Column]
        public int VoyBillId { get; set; }

        [Column]
        public string PaymentMode { get; set; }

        [Column]
        public string PaymentValue { get; set; }

        [Column]
        public string Notes { get; set; }

        private EntityRef<VoyBill> _voyBill;

        [Association(Storage = "_voyBill", ThisKey = "VoyBillId")]
        public VoyBill VoyBills
        {
            get { return this._voyBill.Entity; }
            set { this._voyBill.Entity = value; }
        }

        public VPaymentMode( )
        {
            this._voyBill = new EntityRef<VoyBill>();
        }
    }
}