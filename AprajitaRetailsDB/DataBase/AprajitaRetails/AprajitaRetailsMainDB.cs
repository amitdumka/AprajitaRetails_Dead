namespace AprajitaRetailsDB.DataBase.AprajitaRetails
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AprajitaRetailsMainDB : DbContext
    {
        public AprajitaRetailsMainDB( )
            : base( "AprajitaRetailsMainDB" )
        {
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankDetail> BankDetails { get; set; }
        public virtual DbSet<CardPaymentDetail> CardPaymentDetails { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DailySale> DailySales { get; set; }
        public virtual DbSet<DayClosing> DayClosings { get; set; }
        public virtual DbSet<Expens> Expenses { get; set; }
        public virtual DbSet<ExpensesCategory> ExpensesCategories { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<PaymentMode> PaymentModes { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }
        public virtual DbSet<PurchaseRegister> PurchaseRegisters { get; set; }
        public virtual DbSet<SaleInvoice> SaleInvoices { get; set; }
        public virtual DbSet<SaleItem> SaleItems { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Salesman> Salesmen { get; set; }
        public virtual DbSet<SalesRegister> SalesRegisters { get; set; }
        public virtual DbSet<SaleType> SaleTypes { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockSale> StockSales { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Bank>()
                .Property( e => e.BankName )
                .IsUnicode( false );

            modelBuilder.Entity<Bank>()
                .Property( e => e.AccountNo )
                .IsUnicode( false );

            modelBuilder.Entity<Bank>()
                .Property( e => e.IFSCCode )
                .IsUnicode( false );

            modelBuilder.Entity<Bank>()
                .Property( e => e.Branch )
                .IsUnicode( false );

            modelBuilder.Entity<Bank>()
                .Property( e => e.BranchCity )
                .IsUnicode( false );

            modelBuilder.Entity<Bank>()
                .HasMany( e => e.BankDetails )
                .WithRequired( e => e.Bank )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<BankDetail>()
                .Property( e => e.RefID )
                .IsUnicode( false );

            modelBuilder.Entity<BankDetail>()
                .Property( e => e.BankRef )
                .IsUnicode( false );

            modelBuilder.Entity<BankDetail>()
                .Property( e => e.TranscationRef )
                .IsUnicode( false );

            modelBuilder.Entity<CardPaymentDetail>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<CardPaymentDetail>()
                .Property( e => e.Amount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<CardPaymentDetail>()
                .HasMany( e => e.PaymentDetails )
                .WithOptional( e => e.CardPaymentDetail )
                .HasForeignKey( e => e.CardDetailsID );

            modelBuilder.Entity<Client>()
                .Property( e => e.ClientName )
                .IsUnicode( false );

            modelBuilder.Entity<Client>()
                .Property( e => e.ClientAddress )
                .IsUnicode( false );

            modelBuilder.Entity<Client>()
                .Property( e => e.ClientCity )
                .IsUnicode( false );

            modelBuilder.Entity<Client>()
                .Property( e => e.ClientCode )
                .IsUnicode( false );

            modelBuilder.Entity<Client>()
                .Property( e => e.ClientPhoneNo )
                .IsUnicode( false );

            modelBuilder.Entity<Client>()
                .Property( e => e.ClientGSTNo )
                .IsUnicode( false );

            modelBuilder.Entity<Client>()
                .Property( e => e.ClientVatNo )
                .IsUnicode( false );

            modelBuilder.Entity<Customer>()
                .Property( e => e.FirstName )
                .IsUnicode( false );

            modelBuilder.Entity<Customer>()
                .Property( e => e.LastName )
                .IsUnicode( false );

            modelBuilder.Entity<Customer>()
                .Property( e => e.City )
                .IsUnicode( false );

            modelBuilder.Entity<Customer>()
                .Property( e => e.MobileNo )
                .IsUnicode( false );

            modelBuilder.Entity<Customer>()
                .Property( e => e.TotalAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Customer>()
                .HasMany( e => e.DailySales )
                .WithRequired( e => e.Customer )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<DailySale>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<DailySale>()
                .Property( e => e.Amount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<DailySale>()
                .Property( e => e.Discount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Expens>()
                .Property( e => e.ExpensesReason )
                .IsUnicode( false );

            modelBuilder.Entity<Expens>()
                .Property( e => e.ApprovedBy )
                .IsUnicode( false );

            modelBuilder.Entity<Expens>()
                .Property( e => e.Amount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<ExpensesCategory>()
                .Property( e => e.Category )
                .IsUnicode( false );

            modelBuilder.Entity<PaymentDetail>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<PaymentDetail>()
                .Property( e => e.CashAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<PaymentDetail>()
                .Property( e => e.CardAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<PaymentMode>()
                .Property( e => e.PayMode )
                .IsUnicode( false );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.StyleCode )
                .IsUnicode( false );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.Barcode )
                .IsUnicode( false );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.SupplierId )
                .IsUnicode( false );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.BrandName )
                .IsUnicode( false );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.ProductName )
                .IsUnicode( false );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.ItemDesc )
                .IsUnicode( false );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.MRP )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.Tax )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.Cost )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.Size )
                .IsUnicode( false );

            modelBuilder.Entity<ProductItem>()
                .Property( e => e.Qty )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<ProductItem>()
                .HasMany( e => e.PurchaseItems )
                .WithRequired( e => e.ProductItem )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<ProductItem>()
                .HasMany( e => e.SaleItems )
                .WithRequired( e => e.ProductItem )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<ProductItem>()
                .HasMany( e => e.StockSales )
                .WithRequired( e => e.ProductItem )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.GRNNo )
                .IsUnicode( false );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.SupplierName )
                .IsUnicode( false );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.Barcode )
                .IsUnicode( false );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.ProductName )
                .IsUnicode( false );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.StyleCode )
                .IsUnicode( false );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.ItemDesc )
                .IsUnicode( false );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.MRP )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.MRPValue )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.Cost )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.CostValue )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.TaxAmt )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Purchase>()
                .Property( e => e.IsDataConsumed )
                .IsUnicode( false );

            modelBuilder.Entity<PurchaseItem>()
                .Property( e => e.BarCode )
                .IsUnicode( false );

            modelBuilder.Entity<PurchaseItem>()
                .Property( e => e.MPR )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<PurchaseItem>()
                .Property( e => e.Cost )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<PurchaseRegister>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<PurchaseRegister>()
                .Property( e => e.SupplierName )
                .IsUnicode( false );

            modelBuilder.Entity<PurchaseRegister>()
                .Property( e => e.MRP )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<PurchaseRegister>()
                .Property( e => e.MRPValue )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<PurchaseRegister>()
                .Property( e => e.Cost )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<PurchaseRegister>()
                .Property( e => e.CostValue )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<PurchaseRegister>()
                .Property( e => e.TaxAmt )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleInvoice>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<SaleInvoice>()
                .Property( e => e.TotalQty )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleInvoice>()
                .Property( e => e.TotalBillAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleInvoice>()
                .Property( e => e.TotalDiscountAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleInvoice>()
                .Property( e => e.RoundOffAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleInvoice>()
                .Property( e => e.TotalTaxAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleInvoice>()
                .HasMany( e => e.CardPaymentDetails )
                .WithRequired( e => e.SaleInvoice )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<SaleInvoice>()
                .HasMany( e => e.PaymentDetails )
                .WithRequired( e => e.SaleInvoice )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<SaleInvoice>()
                .HasMany( e => e.SaleItems )
                .WithRequired( e => e.SaleInvoice )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.BarCode )
                .IsUnicode( false );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.Qty )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.MRP )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.BasicAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.Discount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.Tax )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.BillAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.CGST )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SaleItem>()
                .Property( e => e.SGST )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.InvoiceDate )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.InvoiceType )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.BrandName )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.ProductName )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.ItemDescrpetion )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.BarCode )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.StyleCode )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.MRP )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.Discount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.BasicAmt )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.TaxAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.LineTotal )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.RoundOff )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.BillAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.Salesman )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.PaymentMode )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.HSNCode )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.SGST )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.CGST )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Sale>()
                .Property( e => e.LP )
                .IsUnicode( false );

            modelBuilder.Entity<Sale>()
                .Property( e => e.IsDataConsumed )
                .IsUnicode( false );

            modelBuilder.Entity<Salesman>()
                .Property( e => e.SMCode )
                .IsUnicode( false );

            modelBuilder.Entity<Salesman>()
                .Property( e => e.SalesmanName )
                .IsUnicode( false );

            modelBuilder.Entity<Salesman>()
                .HasMany( e => e.SaleItems )
                .WithRequired( e => e.Salesman )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.InvoiceNo )
                .IsUnicode( false );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.InvoiceDate )
                .IsUnicode( false );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.InvoiceType )
                .IsUnicode( false );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.MRP )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.Discount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.BasicAmt )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.TaxAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.RoundOff )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.BillAmount )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<SalesRegister>()
                .Property( e => e.PaymentMode )
                .IsUnicode( false );

            modelBuilder.Entity<SaleType>()
                .Property( e => e.SaleTypeName )
                .IsUnicode( false );

            modelBuilder.Entity<SaleType>()
                .HasMany( e => e.SaleInvoices )
                .WithRequired( e => e.SaleType )
                .WillCascadeOnDelete( false );

            modelBuilder.Entity<Stock>()
                .Property( e => e.BarCode )
                .IsUnicode( false );

            modelBuilder.Entity<Stock>()
                .Property( e => e.CostValue )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Stock>()
                .Property( e => e.MRPValue )
                .HasPrecision( 19, 4 );

            modelBuilder.Entity<Stock>()
                .HasOptional( e => e.ProductItem )
                .WithRequired( e => e.Stock );

            modelBuilder.Entity<StockSale>()
                .Property( e => e.BarCode )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.username )
                .IsUnicode( false );

            modelBuilder.Entity<User>()
                .Property( e => e.passwd )
                .IsUnicode( false );
        }
    }
}
