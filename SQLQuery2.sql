Select InvoiceNo, SaleDate, Amount  from DailySale
where DATEDIFF(Day, SaleDate, '5/2/2017')=0