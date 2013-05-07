using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySpendingLib
{
    /// <summary>
    /// Spending and Income Type
    /// </summary>
    public enum SpendingIncomeType
    { 
        Spending,
        Income,
        Transfer,
        Borrow
    }

    public enum SpendingCategory
    {
        Food,
        Transportation,
        Shopping,
        Entainment,
        Education,
        Living,
        Investment
    }

    public enum AccountType
    {
        Cash,
        Credit,
        Debit,
        PayOnline
    }

    public enum SpendingPerson
    {
        Self,
        Spouse,
        Children,
        Parent,
        Friend
    }

}
