using System;
using System.Collections.Generic;

namespace FinalPrixFinanceApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public decimal? TotalBalance { get; set; }

    public string? Firebase { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
