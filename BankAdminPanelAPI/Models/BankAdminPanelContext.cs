using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankAdminPanelAPI.Models;

public partial class BankAdminPanelContext : DbContext
{
    public BankAdminPanelContext()
    {
    }

    public BankAdminPanelContext(DbContextOptions<BankAdminPanelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AdminUser> AdminUsers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Transection> Transections { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JH2LFHC\\SQLEXPRESS;Initial Catalog=BankAdminPanel;Integrated Security=SSPI;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__Account__BE2ACD6EC76DF6B3");

            entity.ToTable("Account");

            entity.Property(e => e.AccountType).HasMaxLength(20);

            entity.HasOne(d => d.Customer).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Customer");
        });

        modelBuilder.Entity<AdminUser>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__AdminUse__719FE488449528B9");

            entity.ToTable("AdminUser");

            entity.HasIndex(e => e.UserName, "UQ__AdminUse__C9F28456CE1E2E9A").IsUnique();

            entity.Property(e => e.PasswordHash).HasMaxLength(200);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D87C6AA291");

            entity.ToTable("Customer");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Transection>(entity =>
        {
            entity.HasKey(e => e.TransectionId).HasName("PK__Transect__6FA9571284A3B4EE");

            entity.ToTable("Transection");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.Transections)
                .HasForeignKey(d => d.AccountNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transection_Account");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
