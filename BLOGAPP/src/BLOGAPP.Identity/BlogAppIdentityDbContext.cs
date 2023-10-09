using BLOGAPP.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BLOGAPP.Identity.Configurations;
using System.Collections.Generic;
using System.Text;

namespace BLOGAPP.Identity;

public class BLOGAPPIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public BLOGAPPIdentityDbContext(DbContextOptions<BLOGAPPIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }
}

