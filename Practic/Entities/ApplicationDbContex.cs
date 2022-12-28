using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Entities.Order;
using Shop.Entities.Product;
using Shop.Entities.Requset;
using Shop.Images;
using Users.Entities;


public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductComment> ProductComments { get; set; }
    public DbSet<ProductImages> ProductImages { get; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<MokamelRequsets> MokamelRequsets { get; set; }
    public DbSet<PlanRequest> PlanRequests { get; set; }
    public DbSet<Test> Tests { get; set; }

}
