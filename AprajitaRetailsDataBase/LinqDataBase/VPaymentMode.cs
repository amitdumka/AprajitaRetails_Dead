using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.VPaymentMode")]
public partial class VPaymentMode : INotifyPropertyChanging, INotifyPropertyChanged
{

    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

    private int _ID;

    private int _VoyBillId;

    private string _PaymentMode;

    private string _PaymentValue;

    private string _Notes;

    #region Extensibility Method Definitions
    partial void OnLoaded( );
    partial void OnValidate( System.Data.Linq.ChangeAction action );
    partial void OnCreated( );
    partial void OnIDChanging( int value );
    partial void OnIDChanged( );
    partial void OnVoyBillIdChanging( int value );
    partial void OnVoyBillIdChanged( );
    partial void OnPaymentModeChanging( string value );
    partial void OnPaymentModeChanged( );
    partial void OnPaymentValueChanging( string value );
    partial void OnPaymentValueChanged( );
    partial void OnNotesChanging( string value );
    partial void OnNotesChanged( );
    #endregion


    #region ForigenKey
    private EntityRef<VoyBill> _VoyBill;
    [Association(Storage = "_VoyBill", ThisKey = "VoyBillId")]
    public VoyBill VoyBill
    {
        get { return this._VoyBill.Entity; }
        set { this._VoyBill.Entity = value; }
    }
    public VPaymentMode( )
    {
        this._VoyBill = new EntityRef<VoyBill>();
        OnCreated();
    }
    #endregion ForigenKey


    [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
    public int ID
    {
        get
        {
            return this._ID;
        }
        set
        {
            if ((this._ID != value))
            {
                this.OnIDChanging(value);
                this.SendPropertyChanging();
                this._ID = value;
                this.SendPropertyChanged("ID");
                this.OnIDChanged();
            }
        }
    }

    [Column(Storage = "_VoyBillId", DbType = "Int NOT NULL")]
    public int VoyBillId
    {
        get
        {
            return this._VoyBillId;
        }
        set
        {
            if ((this._VoyBillId != value))
            {
                this.OnVoyBillIdChanging(value);
                this.SendPropertyChanging();
                this._VoyBillId = value;
                this.SendPropertyChanged("VoyBillId");
                this.OnVoyBillIdChanged();
            }
        }
    }

    [Column(Storage = "_PaymentMode", DbType = "NVarChar(4000)")]
    public string PaymentMode
    {
        get
        {
            return this._PaymentMode;
        }
        set
        {
            if ((this._PaymentMode != value))
            {
                this.OnPaymentModeChanging(value);
                this.SendPropertyChanging();
                this._PaymentMode = value;
                this.SendPropertyChanged("PaymentMode");
                this.OnPaymentModeChanged();
            }
        }
    }

    [Column(Storage = "_PaymentValue", DbType = "NVarChar(4000)")]
    public string PaymentValue
    {
        get
        {
            return this._PaymentValue;
        }
        set
        {
            if ((this._PaymentValue != value))
            {
                this.OnPaymentValueChanging(value);
                this.SendPropertyChanging();
                this._PaymentValue = value;
                this.SendPropertyChanged("PaymentValue");
                this.OnPaymentValueChanged();
            }
        }
    }

    [Column(Storage = "_Notes", DbType = "NVarChar(4000)")]
    public string Notes
    {
        get
        {
            return this._Notes;
        }
        set
        {
            if ((this._Notes != value))
            {
                this.OnNotesChanging(value);
                this.SendPropertyChanging();
                this._Notes = value;
                this.SendPropertyChanged("Notes");
                this.OnNotesChanged();
            }
        }
    }

    public event PropertyChangingEventHandler PropertyChanging;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void SendPropertyChanging( )
    {
        if ((this.PropertyChanging != null))
        {
            this.PropertyChanging(this, emptyChangingEventArgs);
        }
    }

    protected virtual void SendPropertyChanged( String propertyName )
    {
        if ((this.PropertyChanged != null))
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}