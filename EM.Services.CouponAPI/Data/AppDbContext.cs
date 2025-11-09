using EM.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EM.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon { 
                CouponCode = "KKK001",
                CouponId = 1,
                DiscountAmount = 10,
                MinAmount = 30,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponCode = "KKK002",
                CouponId = 2,
                DiscountAmount = 20,
                MinAmount = 50,
            });
        }
    }
}
