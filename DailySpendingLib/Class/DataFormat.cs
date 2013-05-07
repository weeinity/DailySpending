using System;
using System.Collections.Generic;

namespace DailySpendingLib
{
    public class DataFormat
    {
        public string SpendingIncomeType { get; set; }
        public string Amount { get; set; }
        public string Business { get; set; }
        public string SpendingCategory { get; set; }
        public string AccountType { get; set; }
        public string SpendingPerson { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }

        public DataFormat(string spendingIncomeType,
            string amount,
            string business,
            string spendingCategory, 
            string accountType, 
            string spendingPerson,
            string year,
            string month,
            string day)
        {
            this.SpendingIncomeType = spendingIncomeType;
            this.Amount = amount;
            this.Business = business;
            this.SpendingCategory = spendingCategory;
            this.AccountType = accountType;
            this.SpendingPerson = spendingPerson;
            this.Year = year;
            this.Month = month;
            this.Day = day;

        }
    }
    
}
