using BakoraAPI.Entities.Entities;
using BakoraAPI.Repository.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BakoraAPI.Repository;

public class RepositoryContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configuration Data
        builder.ApplyConfiguration(new RoleConfiguration());
        
    }

    //DbSets
    public DbSet<Admin>? Admins { get; set; }
    public DbSet<Provider>? Providers { get; set; }
    public DbSet<Requester>? Requesters { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Medicines>? Medicines { get; set; }
    public DbSet<OrderItems>? OrderItems { get; set; }
    public DbSet<Cart>? Carts { get; set; }

}
