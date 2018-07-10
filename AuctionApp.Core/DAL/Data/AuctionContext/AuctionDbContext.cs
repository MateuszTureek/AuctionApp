using AuctionApp.Core.DAL.Data.AuctionContext.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Core.DAL.Data.AuctionContext
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
            : base(options) { }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<ItemDescription> ItemDescriptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Delivery> DeliveryMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(item =>
            {
                item.HasKey(k => k.Id);
                item.Property(p => p.Name).HasMaxLength(50).IsRequired();
                item.Property(p => p.ImgSrc).IsRequired();
                item.Property(p => p.ConstPrice).HasColumnType("decimal(16,2)");
                item.Property(p => p.Status).IsRequired();
                item.Property(p => p.UserName).HasMaxLength(256).IsRequired();

                item
                .HasOne(o => o.Auction)
                .WithOne(o => o.Item)
                .IsRequired(false)
                .HasForeignKey<Item>(f => f.AuctionRef)
                .OnDelete(DeleteBehavior.Cascade);

                item
                .HasOne(o => o.Subcategory)
                .WithMany(m => m.Items)
                .IsRequired()
                .HasForeignKey(f => f.SubcategoryRef)
                .OnDelete(DeleteBehavior.ClientSetNull);

                item
                .HasOne(o => o.Delivery)
                .WithMany(m => m.Items)
                .IsRequired()
                .HasForeignKey(f => f.DeliveryRef)
                .OnDelete(DeleteBehavior.ClientSetNull);

                item
                .HasMany(m => m.ItemDescriptions)
                .WithOne(o => o.Item)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Bid>(bid =>
            {
                bid.HasKey(k => k.Id);
                bid.Property(p => p.BidAmount).HasColumnType("decimal(16,2)").IsRequired();
                bid.Property(p => p.DatePlaced).IsRequired();
                bid.Property(p => p.Username).HasMaxLength(256).IsRequired();
            });

            modelBuilder.Entity<Category>(cat =>
            {
                cat.HasKey(k => k.Id);
                cat.Property(p => p.Name).HasMaxLength(50).IsRequired();
                cat.Property(p => p.Position).IsRequired();

                cat
                .HasMany(m => m.Subcategories)
                .WithOne(o => o.Category)
                .IsRequired()
                .HasForeignKey(f => f.CategoryRef)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Delivery>(payment =>
            {
                payment.HasKey(k => k.Id);
                payment.Property(p => p.Name).HasMaxLength(50).IsRequired();
                payment.Property(p => p.DeliveryTime);
                payment.Property(p => p.Price).HasColumnType("decimal(16,2)").IsRequired();
            });

            modelBuilder.Entity<ItemDescription>(itemDesc =>
            {
                itemDesc.HasKey(k => k.Id);
                itemDesc.Property(p => p.Key).HasMaxLength(80).IsRequired();
                itemDesc.Property(p => p.Value).IsRequired();
            });

            modelBuilder.Entity<Subcategory>(cat =>
            {
                cat.HasKey(k => k.Id);
                cat.Property(p => p.Name).HasMaxLength(50).IsRequired();
                cat.Property(p => p.Position).IsRequired();
            });

            modelBuilder.Entity<Auction>(auction =>
            {
                auction.HasKey(k => k.Id);
                auction.Property(p => p.BestBidId).IsRequired(false);
                auction.Property(p => p.StartDate);
                auction.Property(p => p.EndDate);

                auction
                .HasMany(m => m.Bids)
                .WithOne(o => o.Auction)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
