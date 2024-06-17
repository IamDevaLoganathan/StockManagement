using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockManagement.Models.DomainModels;

namespace StockManagement.DataAccess.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<StockDomain> Stocks { get; set; }
    public DbSet<WatchListDomain> WatchLists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var readerRoleId = "dcf8b026-6d74-4cae-bb96-b4eef876acec";
        var writerRoleId = "3436e5e5-2d1e-45fb-856c-fec3de1ab568";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }

        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}

