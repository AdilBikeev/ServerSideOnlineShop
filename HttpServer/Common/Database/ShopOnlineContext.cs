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
