namespace Nhom15_WebVanPhongPham.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        [Key]
        public int Ma { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        [StringLength(50)]
        public string NoiDung { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }
    }
}
