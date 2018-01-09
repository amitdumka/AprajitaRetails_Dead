﻿using System;

namespace AprajitaRetails.Voy
{
    class VBEle
    {

        public const string type = "type";
        public const string bill_number = "bill_number";
        public const string billing_time = "billing_time";
        public const string bill_amount = "bill_amount";
        public const string bill_gross_amount = "bill_gross_amount";
        public const string bill_discount = "bill_discount";
        public const string line_items = "line_items";
        public const string line_item = "line_item";
        public const string line_item_type = "line_item_type";
        public const string serial = "serial";
        public const string item_code = "item_code";
        public const string qty = "qty";
        public const string rate = "rate";
        public const string value = "value";
        public const string discount_value = "discount_value";
        public const string amount = "amount";
        public const string description = "description";

        public const string customer = "customer";
        public const string customername = "name";
        public const string mobile = "mobile";

        public const string Payment_Mode = "Payment_Mode";
        public const string Payment_detail = "Payment_detail";
        public const string payment = "payment";
        public const string mode = "mode";
        public const string Payvalue = "value";
        public const string notes = "notes";



    }
    class VoyBill
    {
        public int ID { get; set; }
        public string BillType { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillTime { get; set; }
        public double BillAmount { get; set; }
        public double BillGrossAmount { get; set; }
        public double BillDiscount { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }



    }
    class LineItems
    {
        public int ID { get; set; }
        public int VoyBillId { get; set; }
        public string line_item_type { get; set; }
        public int Serial { get; set; }
        public string ItemCode { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }
        public double Value { get; set; }
        public double DiscountValue { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
    class VPaymentMode
    {
        public int ID { get; set; }
        public int VoyBillId { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentValue { get; set; }
        public string Notes { get; set; }
    }
}
