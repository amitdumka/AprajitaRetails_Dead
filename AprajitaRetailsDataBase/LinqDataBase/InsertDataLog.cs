using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

[global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.InsertDataLog")]
public partial class InsertDataLog : INotifyPropertyChanging, INotifyPropertyChanged
{

    private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

    private int _ID;

    private string _BillNumber;

    private int _VoyBillId;

    private System.Data.Linq.Binary _CreatedDate;

    private System.DateTime _InsertedOn;

    private System.Nullable<int> _SaleInvoiceId;

    private System.Nullable<int> _DailySaleId;

    private string _Remark;

    #region Extensibility Method Definitions
    partial void OnLoaded( );
    partial void OnValidate( System.Data.Linq.ChangeAction action );
    partial void OnCreated( );
    partial void OnIDChanging( int value );
    partial void OnIDChanged( );
    partial void OnBillNumberChanging( string value );
    partial void OnBillNumberChanged( );
    partial void OnVoyBillIdChanging( int value );
    partial void OnVoyBillIdChanged( );
    partial void OnCreatedDateChanging( System.Data.Linq.Binary value );
    partial void OnCreatedDateChanged( );
    partial void OnInsertedOnChanging( System.DateTime value );
    partial void OnInsertedOnChanged( );
    partial void OnSaleInvoiceIdChanging( System.Nullable<int> value );
    partial void OnSaleInvoiceIdChanged( );
    partial void OnDailySaleIdChanging( System.Nullable<int> value );
    partial void OnDailySaleIdChanged( );
    partial void OnRemarkChanging( string value );
    partial void OnRemarkChanged( );
    #endregion

    public InsertDataLog( )
    {
        OnCreated();
    }

    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
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

    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_BillNumber", DbType = "NVarChar(MAX) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
    public string BillNumber
    {
        get
        {
            return this._BillNumber;
        }
        set
        {
            if ((this._BillNumber != value))
            {
                this.OnBillNumberChanging(value);
                this.SendPropertyChanging();
                this._BillNumber = value;
                this.SendPropertyChanged("BillNumber");
                this.OnBillNumberChanged();
            }
        }
    }

    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_VoyBillId", DbType = "Int NOT NULL", UpdateCheck = UpdateCheck.Never)]
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

    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_CreatedDate", AutoSync = AutoSync.Always, DbType = "rowversion NOT NULL", CanBeNull = false, IsDbGenerated = true, IsVersion = true, UpdateCheck = UpdateCheck.Never)]
    public System.Data.Linq.Binary CreatedDate
    {
        get
        {
            return this._CreatedDate;
        }
        set
        {
            if ((this._CreatedDate != value))
            {
                this.OnCreatedDateChanging(value);
                this.SendPropertyChanging();
                this._CreatedDate = value;
                this.SendPropertyChanged("CreatedDate");
                this.OnCreatedDateChanged();
            }
        }
    }

    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_InsertedOn", DbType = "DateTime2 NOT NULL", UpdateCheck = UpdateCheck.Never)]
    public System.DateTime InsertedOn
    {
        get
        {
            return this._InsertedOn;
        }
        set
        {
            if ((this._InsertedOn != value))
            {
                this.OnInsertedOnChanging(value);
                this.SendPropertyChanging();
                this._InsertedOn = value;
                this.SendPropertyChanged("InsertedOn");
                this.OnInsertedOnChanged();
            }
        }
    }

    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_SaleInvoiceId", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
    public System.Nullable<int> SaleInvoiceId
    {
        get
        {
            return this._SaleInvoiceId;
        }
        set
        {
            if ((this._SaleInvoiceId != value))
            {
                this.OnSaleInvoiceIdChanging(value);
                this.SendPropertyChanging();
                this._SaleInvoiceId = value;
                this.SendPropertyChanged("SaleInvoiceId");
                this.OnSaleInvoiceIdChanged();
            }
        }
    }

    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_DailySaleId", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
    public System.Nullable<int> DailySaleId
    {
        get
        {
            return this._DailySaleId;
        }
        set
        {
            if ((this._DailySaleId != value))
            {
                this.OnDailySaleIdChanging(value);
                this.SendPropertyChanging();
                this._DailySaleId = value;
                this.SendPropertyChanged("DailySaleId");
                this.OnDailySaleIdChanged();
            }
        }
    }

    [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Remark", DbType = "NVarChar(MAX)", UpdateCheck = UpdateCheck.Never)]
    public string Remark
    {
        get
        {
            return this._Remark;
        }
        set
        {
            if ((this._Remark != value))
            {
                this.OnRemarkChanging(value);
                this.SendPropertyChanging();
                this._Remark = value;
                this.SendPropertyChanged("Remark");
                this.OnRemarkChanged();
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