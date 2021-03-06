namespace BlazorAppETF.Model;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/**
 * Database context for identity  
 */
public class IdentityDataContext : IdentityDbContext<IdentityUser>
{
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options)
        : base(options)
    { 
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}