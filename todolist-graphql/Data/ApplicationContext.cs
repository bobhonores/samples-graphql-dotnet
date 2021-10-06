using Microsoft.EntityFrameworkCore;
using Sample.ToDoList.GraphQL.Models;

namespace Sample.ToDoList.GraphQL.Data
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<List> Lists { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(list => list.Id);

                entity.HasMany(list => list.Items)
                    .WithOne(item => item.List)
                    .HasForeignKey(item => item.ListId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(item => item.Id);
            });
        }
    }
}