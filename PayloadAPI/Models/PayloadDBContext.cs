using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PayloadAPI.Models;

public partial class PayloadDbContext : DbContext
{
    public PayloadDbContext()
    {
    }

    public PayloadDbContext(DbContextOptions<PayloadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Payload> Payloads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-O0PM54S;Initial Catalog=PayloadDB;User Id=sa;Password=framework2010;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payload>(entity =>
        {
            entity.ToTable("Payload");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Deviceid)
                .HasMaxLength(50)
                .HasColumnName("deviceid");
            entity.Property(e => e.Humidity).HasColumnName("humidity");
            entity.Property(e => e.Occupancy).HasColumnName("occupancy");
            entity.Property(e => e.Temperature).HasColumnName("temperature");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
