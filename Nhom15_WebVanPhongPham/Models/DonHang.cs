namespace Nhom15_WebVanPhongPham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTiet_DH = new HashSet<ChiTiet_DH>();
        }

        [Key]
        public int MaDH { get; set; }

        public int MaTk { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_DH> ChiTiet_DH { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
