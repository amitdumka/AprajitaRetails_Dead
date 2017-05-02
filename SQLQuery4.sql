 select TAmount, MAmount, YAmount 
 from 
(select  Sum(Amount) as TAmount  from DailySale
 where datediff(day, SaleDate, '2017/04/29') = 0  ) as DS,
 
 (select Sum(Amount) as MAmount ,DatePart(MM, SaleDate) as Months, DatePart(YY, SaleDate) as Years from DailySale
 where 	  DatePart(MM, SaleDate)=04	  and DatePart(YY, SaleDate)=2017
 Group By DatePart(MM, SaleDate) ,DatePart(YY, SaleDate) ) as MS ,

 (
 select Sum(Amount) as YAmount , DatePart(YY, SaleDate) as Years from DailySale
 where 	 DatePart(YY, SaleDate)=2017
 Group By DatePart(YY, SaleDate) ) as YS