using ArmyWebAppUI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArmyWebAppUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Weapon> Weapons { get; set; }
        
        public DbSet<ArmyType> ArmyTypes { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<CartDetail> CartDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

    }
}
