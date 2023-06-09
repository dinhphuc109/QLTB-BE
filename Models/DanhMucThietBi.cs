using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class DanhMucThietBi: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaThietBi { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Tên bắt buộc")]
        public string TenThietBi { get; set; }
        [StringLength(50)]
        public string CauHinh { get; set; }

        [ForeignKey("HangThietBi")]
        public Guid? HangThietBi_Id { get; set; }
        [ForeignKey("LoaiThietBi")]
        public Guid? LoaiThietbi_Id { get; set; }
        public HangThietBi HangThietBi { get; set; }
        public LoaiThietBi LoaiThietBi { get; set; }
        public ICollection<ThongTinThietBi> ThongTinThietBis { get; set; }

    }
}
