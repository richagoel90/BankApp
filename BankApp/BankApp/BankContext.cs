﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class BankContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:bankapplicationuidbserver.database.windows.net,1433;Initial Catalog=BankApplicationUI_db;Persist Security Info=False;User ID=Bankadmin;Password=Redmond@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.AccountNumber).HasName("PK_Accounts");
                entity.Property(a => a.AccountNumber).ValueGeneratedOnAdd();
                entity.Property(a => a.EmailAddress).IsRequired().HasMaxLength(100);
                entity.Property(a => a.AccountType).IsRequired();
                entity.ToTable("Accounts");
            });
            modelBuilder.Entity<Transaction>(entity =>
           {
               entity.HasKey(t => t.Id).HasName("PK_Transactions");
               entity.Property(t => t.Id).ValueGeneratedOnAdd();
               entity.Property(t => t.Amount).IsRequired();
               entity.HasOne(t => t.Account).WithMany().HasForeignKey(t=> t.AccountNumber);
           });
        }

    }
}
