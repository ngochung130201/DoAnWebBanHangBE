using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Models
{
    public class ComputerdbContext : DbContext
    {
        public ComputerdbContext(DbContextOptions<ComputerdbContext> options) : base(options)
        {

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PostComment> PostComments  { get; set; }
        public DbSet<ProductComment> ProductComments  { get; set; }
        public DbSet<Slider> Sliders  { get; set; }
        public DbSet<Supplier> Suppliers  { get; set; }
        
        
    }
}
