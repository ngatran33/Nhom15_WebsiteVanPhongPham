namespace Nhom15_WebVanPhongPham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTiet_DH
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSp { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDH { get; set; }

        public int? SLBan { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
