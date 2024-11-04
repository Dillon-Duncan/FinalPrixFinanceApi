using System;
using System.Collections.Generic;

namespace FinalPrixFinanceApi.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? UserId { get; set; }

    public string? TransactionName { get; set; }

    public decimal? Amount { get; set; }

    public string? Category { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public virtual User? User { get; set; }
}
