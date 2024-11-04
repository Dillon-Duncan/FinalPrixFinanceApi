using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FinalPrixFinanceApi.Models;

public partial class FinalPrixFinanceContext : DbContext
{
    public FinalPrixFinanceContext()
    {
    }

    public FinalPrixFinanceContext(DbContextOptions<FinalPrixFinanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => e.BudgetId).HasName("PK__Budgets__3A655C1402C54082");

            entity.Property(e => e.BudgetId).HasColumnName("budget_id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Limit)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("limit");
            entity.Property(e => e.TotalExpenses)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_expenses");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Budgets__user_id__656C112C");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK__Goals__76679A244AFCF5BF");

            entity.Property(e => e.GoalId).HasColumnName("goal_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.Period)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("period");
            entity.Property(e => e.TargetAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("target_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Goals__user_id__5FB337D6");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AFEAC313B7");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TransactionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("transaction_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Transacti__user___628FA481");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F24C331A4");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164AB16DE93").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firebase)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("firebase");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.TotalBalance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_balance");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}