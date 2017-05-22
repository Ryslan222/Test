using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Tag> Tag { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>().HasMany(c => c.Item)
                .WithMany(s => s.Tag)
                .Map(t => t.MapLeftKey("TagId")
                .MapRightKey("ItemId")
                .ToTable("TagItem"));
        }

        
    }
}