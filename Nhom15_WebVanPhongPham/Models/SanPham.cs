namespace Nhom15_WebVanPhongPham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTiet_DH = new HashSet<ChiTiet_DH>();
        }

        [Key]
        public int MaSp { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int MaDM { get; set; }

        public double? KhoiLuong { get; set; }

        public int? SLcon { get; set; }

        [StringLength(50)]
        public string ThuongHieu { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        [StringLength(100)]
        public string MoTa { get; set; }

        public double Gia { get; set; }

        public int SLDat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_DH> ChiTiet_DH { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
