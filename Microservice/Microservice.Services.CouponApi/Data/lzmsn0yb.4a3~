using Microservice.Services.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Services.CouponApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1,
                    CouponCode = "10OFF",
                    DiscountAmount = 10,
                    MinimumAmount = 50
                },
                new Coupon
                {
                    Id = 2,
                    CouponCode = "20OFF",
                    DiscountAmount = 20,
                    MinimumAmount = 100
                }
            );
        }
    }
}
