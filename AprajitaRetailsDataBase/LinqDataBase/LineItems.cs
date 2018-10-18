using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.LineItems")]
public partial class LineItems : INotifyPropertyChanging, INotifyPropertyChanged
{

    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

    private int _ID;

    private int _VoyBillId;

    private string _LineType;

    private int _Serial;

    private string _ItemCode;

    private double _Qty;

    private double _Rate;

    private double _Value;

    private double _DiscountValue;

    private double _Amount;

    private string _Description;

    #region Extensibility Method Definitions
    partial void OnLoaded( );
    partial void OnValidate( System.Data.Linq.ChangeAction action );
    partial void OnCreated( );
    partial void OnIDChanging( int value );
    partial void OnIDChanged( );
    partial void OnVoyBillIdChanging( int value );
    partial void OnVoyBillIdChanged( );
    partial void OnLineTypeChanging( string value );
    partial void OnLineTypeChanged( );
    partial void OnSerialChanging( int value );
    partial void OnSerialChanged( );
    partial void OnItemCodeChanging( string value );
    partial void OnItemCodeChanged( );
    partial void OnQtyChanging( double value );
    partial void OnQtyChanged( );
    partial void OnRateChanging( double value );
    partial void OnRateChanged( );
    partial void OnValueChanging( double value );
    partial void OnValueChanged( );
    partial void OnDiscountValueChanging( double value );
    partial void OnDiscountValueChanged( );
    partial void OnAmountChanging( double value );
    partial void OnAmountChanged( );
    partial void OnDescriptionChanging( string value );
    partial void OnDescriptionChanged( );
    #endregion

    #region ForigenKey
    private EntityRef<VoyBill> _VoyBill;
    [Association(Storage = "_VoyBill", ThisKey = "VoyBillId")]
    public VoyBill VoyBill
    {
        get { return this._VoyBill.Entity; }
        set { this._VoyBill.Entity = value; }
    }
    public LineItems( )
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

    [Column(Storage = "_LineType", DbType = "NVarChar(4000)")]
    public string LineType
    {
        get
        {
            return this._LineType;
        }
        set
        {
            if ((this._LineType != value))
            {
                this.OnLineTypeChanging(value);
                this.SendPropertyChanging();
                this._LineType = value;
                this.SendPropertyChanged("LineType");
                this.OnLineTypeChanged();
            }
        }
    }

    [Column(Storage = "_Serial", DbType = "Int NOT NULL")]
    public int Serial
    {
        get
        {
            return this._Serial;
        }
        set
        {
            if ((this._Serial != value))
            {
                this.OnSerialChanging(value);
                this.SendPropertyChanging();
                this._Serial = value;
                this.SendPropertyChanged("Serial");
                this.OnSerialChanged();
            }
        }
    }

    [Column(Storage = "_ItemCode", DbType = "NVarChar(4000)")]
    public string ItemCode
    {
        get
        {
            return this._ItemCode;
        }
        set
        {
            if ((this._ItemCode != value))
            {
                this.OnItemCodeChanging(value);
                this.SendPropertyChanging();
                this._ItemCode = value;
                this.SendPropertyChanged("ItemCode");
                this.OnItemCodeChanged();
            }
        }
    }

    [Column(Storage = "_Qty", DbType = "Float NOT NULL")]
    public double Qty
    {
        get
        {
            return this._Qty;
        }
        set
        {
            if ((this._Qty != value))
            {
                this.OnQtyChanging(value);
                this.SendPropertyChanging();
                this._Qty = value;
                this.SendPropertyChanged("Qty");
                this.OnQtyChanged();
            }
        }
    }

    [Column(Storage = "_Rate", DbType = "Float NOT NULL")]
    public double Rate
    {
        get
        {
            return this._Rate;
        }
        set
        {
            if ((this._Rate != value))
            {
                this.OnRateChanging(value);
                this.SendPropertyChanging();
                this._Rate = value;
                this.SendPropertyChanged("Rate");
                this.OnRateChanged();
            }
        }
    }

    [Column(Storage = "_Value", DbType = "Float NOT NULL")]
    public double Value
    {
        get
        {
            return this._Value;
        }
        set
        {
            if ((this._Value != value))
            {
                this.OnValueChanging(value);
                this.SendPropertyChanging();
                this._Value = value;
                this.SendPropertyChanged("Value");
                this.OnValueChanged();
            }
        }
    }

    [Column(Storage = "_DiscountValue", DbType = "Float NOT NULL")]
    public double DiscountValue
    {
        get
        {
            return this._DiscountValue;
        }
        set
        {
            if ((this._DiscountValue != value))
            {
                this.OnDiscountValueChanging(value);
                this.SendPropertyChanging();
                this._DiscountValue = value;
                this.SendPropertyChanged("DiscountValue");
                this.OnDiscountValueChanged();
            }
        }
    }

    [Column(Storage = "_Amount", DbType = "Float NOT NULL")]
    public double Amount
    {
        get
        {
            return this._Amount;
        }
        set
        {
            if ((this._Amount != value))
            {
                this.OnAmountChanging(value);
                this.SendPropertyChanging();
                this._Amount = value;
                this.SendPropertyChanged("Amount");
                this.OnAmountChanged();
            }
        }
    }

    [Column(Storage = "_Description", DbType = "NVarChar(4000)")]
    public string Description
    {
        get
        {
            return this._Description;
        }
        set
        {
            if ((this._Description != value))
            {
                this.OnDescriptionChanging(value);
                this.SendPropertyChanging();
                this._Description = value;
                this.SendPropertyChanged("Description");
                this.OnDescriptionChanged();
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