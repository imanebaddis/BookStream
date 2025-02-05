using BookStream.Domain.Books.Entities;
using BookStream.Domain.Categories.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStream.Infrastructure.Common.Persistence.Data
{
    public class BookStreamDbContext : DbContext
    {
        public BookStreamDbContext(DbContextOptions<BookStreamDbContext> options)
            : base(options)
        {
        }

        public required DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity=>{
                entity.ToTable("books");
                entity.HasKey(e=>e.Id);
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e=>e.Title).HasColumnName("title").IsRequired().HasMaxLength(100);
                entity.Property(e=>e.Author).HasColumnName("author").IsRequired().HasMaxLength(100);
                entity.Property(e=>e.PublishedDate).HasColumnName("published_date").HasColumnType("timestamp").IsRequired();
                entity.Property(e=>e.Price).HasColumnName("price").IsRequired();
            });

            modelBuilder.Entity<Category>(entity=>{
                entity.ToTable("categories");
                entity.HasKey(e=>e.Id);
                entity.Property(e => e.Id).HasColumnName("id").IsRequired();
                entity.Property(e=>e.Name).HasColumnName("title").IsRequired().HasMaxLength(100);
                entity.Property(e=>e.IsActive).HasColumnName("is_active").IsRequired();
                entity.Property(e=>e.CreatedBy).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();
                entity.Property(e=>e.CreatedAt).HasColumnName("created_by");
                entity.Property(e=>e.ModifiedAt).HasColumnName("modified_at").HasColumnType("timestamp").IsRequired();
                entity.Property(e=>e.ModifiedBy).HasColumnName("modified_by");
            });

        }
    }
}