using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace AprajitaRetailsDataBase.LinqDataBase
{
    [global::System.Data.Linq.Mapping.TableAttribute( Name = "dbo.VoyBill" )]
    public partial class VoyBill : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs( String.Empty );

        private int _ID;

        private string _BillType;

        private string _BillNumber;

        private System.Nullable<System.DateTime> _BillTime;

        private double _BillAmount;

        private double _BillGrossAmount;

        private double _BillDiscount;

        private string _CustomerName;

        private string _CustomerMobile;

        private string _StoreID;

        #region Forenkey

        private EntitySet<VPaymentMode> _VPaymentMode;
        private EntitySet<LineItems> _LineItems;

        public VoyBill( )
        {
            this._LineItems=new EntitySet<LineItems>();
            this._VPaymentMode=new EntitySet<VPaymentMode>();

            OnCreated();
        }

        [Association( Storage = "_LineItems", OtherKey = "ID" )]
        public EntitySet<LineItems> LineItems
        {
            get { return this._LineItems; }
            set { this._LineItems.Assign( value ); }
        }

        [Association( Storage = "_VPaymentMode", OtherKey = "ID" )]
        public EntitySet<VPaymentMode> VPaymentMode
        {
            get { return this._VPaymentMode; }
            set { this._VPaymentMode.Assign( value ); }
        }

        #endregion Forenkey

        #region Extensibility Method Definitions

        partial void OnLoaded( );

        partial void OnValidate( System.Data.Linq.ChangeAction action );

        partial void OnCreated( );

        partial void OnIDChanging( int value );

        partial void OnIDChanged( );

        partial void OnBillTypeChanging( string value );

        partial void OnBillTypeChanged( );

        partial void OnBillNumberChanging( string value );

        partial void OnBillNumberChanged( );

        partial void OnBillTimeChanging( System.Nullable<System.DateTime> value );

        partial void OnBillTimeChanged( );

        partial void OnBillAmountChanging( double value );

        partial void OnBillAmountChanged( );

        partial void OnBillGrossAmountChanging( double value );

        partial void OnBillGrossAmountChanged( );

        partial void OnBillDiscountChanging( double value );

        partial void OnBillDiscountChanged( );

        partial void OnCustomerNameChanging( string value );

        partial void OnCustomerNameChanged( );

        partial void OnCustomerMobileChanging( string value );

        partial void OnCustomerMobileChanged( );

        partial void OnStoreIDChanging( string value );

        partial void OnStoreIDChanged( );

        #endregion Extensibility Method Definitions

        [Column( Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true )]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID!=value))
                {
                    this.OnIDChanging( value );
                    this.SendPropertyChanging();
                    this._ID=value;
                    this.SendPropertyChanged( "ID" );
                    this.OnIDChanged();
                }
            }
        }

        [Column( Storage = "_BillType", DbType = "NVarChar(4000)" )]
        public string BillType
        {
            get
            {
                return this._BillType;
            }
            set
            {
                if ((this._BillType!=value))
                {
                    this.OnBillTypeChanging( value );
                    this.SendPropertyChanging();
                    this._BillType=value;
                    this.SendPropertyChanged( "BillType" );
                    this.OnBillTypeChanged();
                }
            }
        }

        [Column( Storage = "_BillNumber", DbType = "NVarChar(4000)" )]
        public string BillNumber
        {
            get
            {
                return this._BillNumber;
            }
            set
            {
                if ((this._BillNumber!=value))
                {
                    this.OnBillNumberChanging( value );
                    this.SendPropertyChanging();
                    this._BillNumber=value;
                    this.SendPropertyChanged( "BillNumber" );
                    this.OnBillNumberChanged();
                }
            }
        }

        [Column( Storage = "_BillTime", DbType = "DateTime2(7)" )]
        public System.Nullable<System.DateTime> BillTime
        {
            get
            {
                return this._BillTime;
            }
            set
            {
                if ((this._BillTime!=value))
                {
                    this.OnBillTimeChanging( value );
                    this.SendPropertyChanging();
                    this._BillTime=value;
                    this.SendPropertyChanged( "BillTime" );
                    this.OnBillTimeChanged();
                }
            }
        }

        [Column( Storage = "_BillAmount", DbType = "Float NOT NULL" )]
        public double BillAmount
        {
            get
            {
                return this._BillAmount;
            }
            set
            {
                if ((this._BillAmount!=value))
                {
                    this.OnBillAmountChanging( value );
                    this.SendPropertyChanging();
                    this._BillAmount=value;
                    this.SendPropertyChanged( "BillAmount" );
                    this.OnBillAmountChanged();
                }
            }
        }

        [Column( Storage = "_BillGrossAmount", DbType = "Float NOT NULL" )]
        public double BillGrossAmount
        {
            get
            {
                return this._BillGrossAmount;
            }
            set
            {
                if ((this._BillGrossAmount!=value))
                {
                    this.OnBillGrossAmountChanging( value );
                    this.SendPropertyChanging();
                    this._BillGrossAmount=value;
                    this.SendPropertyChanged( "BillGrossAmount" );
                    this.OnBillGrossAmountChanged();
                }
            }
        }

        [Column( Storage = "_BillDiscount", DbType = "Float NOT NULL" )]
        public double BillDiscount
        {
            get
            {
                return this._BillDiscount;
            }
            set
            {
                if ((this._BillDiscount!=value))
                {
                    this.OnBillDiscountChanging( value );
                    this.SendPropertyChanging();
                    this._BillDiscount=value;
                    this.SendPropertyChanged( "BillDiscount" );
                    this.OnBillDiscountChanged();
                }
            }
        }

        [Column( Storage = "_CustomerName", DbType = "NVarChar(4000)" )]
        public string CustomerName
        {
            get
            {
                return this._CustomerName;
            }
            set
            {
                if ((this._CustomerName!=value))
                {
                    this.OnCustomerNameChanging( value );
                    this.SendPropertyChanging();
                    this._CustomerName=value;
                    this.SendPropertyChanged( "CustomerName" );
                    this.OnCustomerNameChanged();
                }
            }
        }

        [Column( Storage = "_CustomerMobile", DbType = "NVarChar(4000)" )]
        public string CustomerMobile
        {
            get
            {
                return this._CustomerMobile;
            }
            set
            {
                if ((this._CustomerMobile!=value))
                {
                    this.OnCustomerMobileChanging( value );
                    this.SendPropertyChanging();
                    this._CustomerMobile=value;
                    this.SendPropertyChanged( "CustomerMobile" );
                    this.OnCustomerMobileChanged();
                }
            }
        }

        [Column( Storage = "_StoreID", DbType = "NVarChar(4000)" )]
        public string StoreID
        {
            get
            {
                return this._StoreID;
            }
            set
            {
                if ((this._StoreID!=value))
                {
                    this.OnStoreIDChanging( value );
                    this.SendPropertyChanging();
                    this._StoreID=value;
                    this.SendPropertyChanged( "StoreID" );
                    this.OnStoreIDChanged();
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging( )
        {
            if ((this.PropertyChanging!=null))
            {
                this.PropertyChanging( this, emptyChangingEventArgs );
            }
        }

        protected virtual void SendPropertyChanged( String propertyName )
        {
            if ((this.PropertyChanged!=null))
            {
                this.PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    }
}