using System;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json.Linq;
using ServerSideOnlineShop.Common.Hellpers;

namespace HttpServer.Common.Database
{
    public partial class ShopOnlineContext : DbContext
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private string connectionString;

        /// <summary>
        /// Путь к файлу с настройками
        /// </summary>
        public static string pathSettings;

        public ShopOnlineContext()
        {
            try
            {
                StreamReader sr;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                using (sr = new StreamReader(pathSettings, Encoding.GetEncoding(1251)))
                {
                    var str = sr.ReadToEnd();
                    JObject json = JObject.Parse(str);

                    this.connectionString = JsonHellper.GetValue(json, "connectionString");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public ShopOnlineContext(DbContextOptions<ShopOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductFeature> ProductFeature { get; set; }
        public virtual DbSet<ProductFeatureSelect> ProductFeatureSelect { get; set; }
        public virtual DbSet<ProductStatus> ProductStatus { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(this.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatePublication)
                    .HasColumnName("datePublication")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.SallerId).HasColumnName("sallerId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Saller)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.SallerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__sallerI__5812160E");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__status__59063A47");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__type__571DF1D5");
            });

            modelBuilder.Entity<ProductFeature>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__tmp_ms_x__F04DF13A6125F77E");

                entity.Property(e => e.TypeId)
                    .HasColumnName("typeId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductFeatureSelect>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__ProductF__2D10D16A346056AC");

                entity.Property(e => e.ProductId)
                    .HasColumnName("productId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(100);

                entity.Property(e => e.Params)
                    .HasColumnName("params")
                    .HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.ProductFeatureSelect)
                    .HasForeignKey<ProductFeatureSelect>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductFe__produ__5629CD9C");
            });

            modelBuilder.Entity<ProductStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FeatureId).HasColumnName("featureId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.ProductType)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductTy__featu__48CFD27E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
