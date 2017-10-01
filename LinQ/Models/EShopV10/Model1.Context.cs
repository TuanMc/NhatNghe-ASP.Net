namespace EFCodeFirst.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EShopV10 : DbContext
    {
        public EShopV10()
            : base("name=EShopV10")
        {
        }
    
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
