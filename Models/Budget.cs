using System;
using System.Collections.Generic;

namespace FinalPrixFinanceApi.Models;

public partial class Budget
{
    public int BudgetId { get; set; }

    public int? UserId { get; set; }

    public string? Category { get; set; }

    public decimal? Limit { get; set; }

    public decimal? TotalExpenses { get; set; }

    public virtual User? User { get; set; }
}
