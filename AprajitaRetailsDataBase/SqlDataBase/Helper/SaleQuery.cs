namespace AprajitaRetailsDataBase.SqlDataBase.ViewModel
{
    public static class SaleQuery
    {
        public static string qYearly = "select sum(Amount),DATEPART(YY,SaleDate) as Year from DailySale " +
                                       "where DATEPART(YY, SaleDate)=@year group by DATEPART(YY, SaleDate)";

        public static string QMontly = "select 	 sum(Amount) as TAmount,DATEPART(MM,SaleDate) as Months, " +
                                       "DATEPART(YY,SaleDate) as Years from DailySale" +
                                       "where DATEPART(YY, SaleDate)=@year    and DATEPART(MM, SaleDate)=@month" +
                                       "group by DATEPART(MM, SaleDate)  , DATEPART(YY, SaleDate)";

        public static string QDaily = "select  Sum(Amount) as TAmount  from DailySale "
                                      + "where datediff(day, SaleDate,@date) = 0 ";

        public static string QueryAll = "select TAmount, MAmount, YAmount  from " +
                                        "(select Sum(Amount) as TAmount from DailySale  where datediff(day, SaleDate, @CDate) = 0  ) as DS," +
                                        "(select Sum(Amount) as MAmount ,DatePart(MM, SaleDate) as Months, DatePart(YY, SaleDate) as Years from DailySale " +
                                        "where    DatePart(MM, SaleDate)=@CMon	  and DatePart(YY, SaleDate)=@CYear " +
                                        "Group By DatePart(MM, SaleDate) ,DatePart(YY, SaleDate) ) as MS , " +
                                        " (  select Sum(Amount) as YAmount , DatePart(YY, SaleDate) as Years from DailySale " +
                                        " where   DatePart(YY, SaleDate)=@CYear2   Group By DatePart(YY, SaleDate) ) as YS";
    }
}