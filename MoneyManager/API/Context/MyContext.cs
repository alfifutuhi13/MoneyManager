using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        { }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionIncome> TransactionIncomes { get; set; }
        public DbSet<TransactionExpense> TransactionExpenses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Email should be unique
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();

            //User - Account(FK) (1 to 1)
            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<Account>(a => a.Id);

            //User(FK) - Role (many to 1)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users);

            //User - Transaction(FK) (1 to 1)
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithOne(u => u.Transaction)
                .HasForeignKey<Transaction>(t => t.Id);

            //Transaction - TransactionIncome(FK) (1 to many)
            modelBuilder.Entity<TransactionIncome>()
                .HasOne(ti => ti.Transaction)
                .WithMany(t => t.TransactionIncomes);

            //TransactionIncome(FK) - Income (many to 1)
            modelBuilder.Entity<TransactionIncome>()
                .HasOne(ti => ti.Income)
                .WithMany(i => i.TransactionIncomes);

            //Transaction - TransactionExpense(FK) (1 to many)
            modelBuilder.Entity<TransactionExpense>()
                .HasOne(te => te.Transaction)
                .WithMany(t => t.TransactionExpenses);

            //TransactionExpense(FK) - Expense (many to 1)
            modelBuilder.Entity<TransactionExpense>()
                .HasOne(te => te.Expense)
                .WithMany(e => e.TransactionExpenses);
        }
    }
}
