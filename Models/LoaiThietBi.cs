using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class LoaiThietBi:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaLoaiThietBi { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Tên bắt buộc")]
        public string TenLoaiThietBi { get; set; }
        [ForeignKey("HeThong")]
        public Guid? HeThong_Id { get; set; }
        public HeThong HeThong { get; set; }

        public Guid? LoaiThietBi_Id { get; set; }

        public virtual LoaiThietBi ParentLoaiThietBi { get; set; }
        public virtual ICollection<LoaiThietBi> ChildLoaiThietBis { get; set; }
        public ICollection<DanhMucThietBi> DanhMucThietBis { get; set; }


    }
}
