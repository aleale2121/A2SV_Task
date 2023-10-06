using BLOGAPP.Domain;
using BLOGAPP.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLOGAPP.Persistence;

public class BLOGAPPDbContext : AuditableDbContext
{
    public BLOGAPPDbContext(DbContextOptions<BLOGAPPDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BLOGAPPDbContext).Assembly);
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
}

