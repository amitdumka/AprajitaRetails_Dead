﻿Select InvoiceNo, SaleDate, Amount  from DailySale
 where DATEDIFF(Day, SaleDate, '4/30/2017')=0