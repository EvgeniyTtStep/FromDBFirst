using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OfficeP32.Proc;
using OfficeP32.Views;

namespace OfficeP32.Models;

public partial class OfficeP32Context : DbContext
{
    public OfficeP32Context()
    {
    }

    public OfficeP32Context(DbContextOptions<OfficeP32Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeClient> EmployeeClients { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }
    
    public virtual DbSet<View_2> View_2s { get; set; }
    
    public virtual DbSet<GetAllEmployees> GetAllEmployees { get; set; }
    
    public virtual DbSet<GetMaxSalary> GetMaxSalary { get; set; }
    

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DFFR2JS\\SQLEXPRESS;Database=OfficeP32;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC074468DA12");

            entity.ToTable("Client");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PK__Employee__3214EC07510C2754");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Phone, "UQ__Employee__5C7E359E3E57C624").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D1053485E1026D").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            
            entity.Property(e => e.NameEmployee)
                .HasMaxLength(150)
                .IsUnicode(false);
            
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(s => s.Salary)
                .HasColumnName("Salary")
                .HasMaxLength(1000)
                .IsUnicode(false);
                

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Employee__Positi__60A75C0F");

            entity.HasOne(d => d.Skills).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SkillsId)
                .HasConstraintName("FK__Employee__Skills__6383C8BA");
        });

        modelBuilder.Entity<EmployeeClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC071D678A44");

            entity.ToTable("EmployeeClient");

            entity.HasOne(d => d.Client).WithMany(p => p.EmployeeClients)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeC__Clien__68487DD7");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeClients)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeC__Emplo__693CA210");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition).HasName("PK__Position__3214EC078F062DCE");

            entity.ToTable("Position");

            entity.Property(e => e.NamePosition)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.IdSkill)
                .HasName("PK__Skills__3214EC07724D3E3E");

            entity.Property(e => e.NameSkill)
                .HasMaxLength(150)
                .IsUnicode(false);
        });
        
        modelBuilder.Entity<View_2>()
            .HasNoKey()
            .ToView("View_2");
        
        modelBuilder.Entity<GetAllEmployees>().HasNoKey()
            .HasNoKey()
            .ToView("GetAllEmployees");
        
        modelBuilder.Entity<GetMaxSalary>().HasNoKey()
            .HasNoKey()
            .ToView("GetMaxSalary");
        
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
