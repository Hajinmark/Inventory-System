using CorpsInventoryManagementSystem.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace CorpsInventoryManagementSystem.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        // Data Table
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Supplier> Suppliers { get; set; }  
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*
            modelBuilder.Entity<Product>()
                        .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasOne<Category>(s => s.Category)
                .WithMany(g => g.Product)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne<Supplier>(s => s.Supplier)
                .WithMany(g => g.Product)
                .HasForeignKey(s => s.SupplierId);

            modelBuilder.Entity<Supplier>()
           .HasKey(p => p.Id);


            modelBuilder.Entity<Supplier>()
                        .HasIndex(s => s.SupplierId)
                        .IsUnique();
            //.HasForeignKey(s => s.SupplierId);

            modelBuilder.Entity<Category>()
            .HasKey(p => p.Id);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryId)
                .IsUnique();
            */
        }
    }
}
