using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace data.models;

public partial class AlicedataContext : DbContext
{
    public DbSet<Log> Logs { get; set; }

    public AlicedataContext()
    {
    }

    public AlicedataContext(DbContextOptions<AlicedataContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseSqlite("Data Source=alicedata.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
