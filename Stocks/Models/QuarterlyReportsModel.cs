using System;
using System.Collections.Generic;
using System.Text;

namespace Stocks.Models
{
    class QuarterlyReportsModel
    {
        private DateTime fiscalDateEnding { get; set; }
        private string reportedCurrency { get; set; }
        private double totalAssets { get; set; }
        private double totalCurrentAssets { get; set; }
        private double cashAndCashEquivalentsAtCarryingValue { get; set; }
        private double cashAndShortTermInvestments { get; set; }
        private double inventory { get; set; }
        private double currentNetReceivables { get; set; }
        private double totalNonCurrentAssets { get; set; }
        private double propertyPlantEquipment { get; set; }
        private double accumulatedDepreciationAmortizationPPE { get; set; }
        private double intangibleAssets { get; set; }
        private double intangibleAssetsExcludingGoodwill { get; set; }
        private double goodwill { get; set; }
        private double investments { get; set; }
        private double longTermInvestments { get; set; }
        private double shortTermInvestments { get; set; }
        private double otherCurrentAssets { get; set; }
        private double otherNonCurrrentAssets { get; set; }
        private double totalLiabilities { get; set; }
        private double totalCurrentLiabilities { get; set; }
        private double currentAccountsPayable { get; set; }
        private double deferredRevenue { get; set; }
        private double currentDebt { get; set; }
        private double shortTermDebt { get; set; }
        private double totalNonCurrentLiabilities { get; set; }
        private double capitalLeaseObligations { get; set; }
        private double longTermDebt { get; set; }
        private double currentLongTermDebt { get; set; }
        private double longTermDebtNoncurrent { get; set; }
        private double shortLongTermDebtTotal { get; set; }
        private double otherCurrentLiabilities { get; set; }
        private double otherNonCurrentLiabilities { get; set; }
        private double totalShareholderEquity { get; set; }
        private double treasuryStock { get; set; }
        private double retainedEarnings { get; set; }
        private double commonStock { get; set; }
        private double commonStockSharesOutstanding { get; set; }
    }
}
