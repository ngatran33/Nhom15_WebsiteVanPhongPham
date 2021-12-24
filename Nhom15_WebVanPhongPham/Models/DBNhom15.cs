namespace Nhom15_WebVanPhongPham.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBNhom15 : DbContext
    {
        public DBNhom15()
            : base("name=DBNhom15")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<ChiTiet_DH> ChiTiet_DH { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.DanhMuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTiet_DH)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTiet_DH)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.MaDH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDN)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.TaiKhoan)
                .WillCascadeOnDelete(false);
        }
    }
}
