using Microsoft.EntityFrameworkCore;
using StoreFlow.Entities;

namespace StoreFlow.Context
{
    public class StoreContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-K8G0IBR\\SQLEXPRESS;Initial Catalog=StoreFlowDb;Integrated Security=True; trust server certificate=true;");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ProductStockHistory> ProductStockHistories { get; set; }
    }
}
