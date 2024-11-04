using System;
using System.Collections.Generic;

namespace FinalPrixFinanceApi.Models;

public partial class Goal
{
    public int GoalId { get; set; }

    public int? UserId { get; set; }

    public decimal? TargetAmount { get; set; }

    public string? Category { get; set; }

    public decimal? Amount { get; set; }

    public string? Period { get; set; }

    public virtual User? User { get; set; }
}
