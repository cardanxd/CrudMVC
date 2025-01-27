using System;
using CrudMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC.Context;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }

    public DbSet<Empleado> Empleados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Empleado>(tb =>
        {
            tb.HasKey(col => col.IdEmpleado);
            tb.Property(col => col.IdEmpleado).UseIdentityColumn().ValueGeneratedOnAdd();
            tb.Property(col => col.NombreCompleto).HasMaxLength(50);
            tb.Property(col => col.Correo).HasMaxLength(50);
        });
    }
}
