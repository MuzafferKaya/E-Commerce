using DomainModel.Configurations;
using DomainModel.Entities.Card;
using DomainModel.Entities.Coupon;
using DomainModel.Entities.Customer;
using DomainModel.Entities.Order;
using DomainModel.Entities.Payment;
using DomainModel.Entities.Product;
using DomainModel.Entities.Shipping;
using DomainModel.Entities.Staff;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;

        public DbSet<StaffAccount> StaffAccounts { get; set; } = null!;
        public DbSet<StaffRole> StaffRoles { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Gallery> Galleries { get; set; } = null!;

        public DbSet<Shipping> Shippings { get; set; } = null!;
        public DbSet<ShippingProvider> ShippingProviders { get; set; } = null!;

        public DbSet<Coupon> Coupons { get; set; } = null!;
        public DbSet<ProductCoupon> ProductCoupons { get; set; } = null!;

        public DbSet<Card> Cards { get; set; } = null!;
        public DbSet<CardItem> CardItems { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        public DbSet<Payment> Payments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CouponConfiguration());
            modelBuilder.ApplyConfiguration(new GalleryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShippingProviderConfiguration());
            modelBuilder.ApplyConfiguration(new StaffAccountConfiguration());
        }
    }
}
