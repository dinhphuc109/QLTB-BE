using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class ThanhLy_Kho : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [ForeignKey("ThanhLyThietBi")]
        public Guid ThanhLyThietBi_Id { get; set; }
        public ThanhLyThietBi ThanhLyThietBi { get; set; }

        [ForeignKey("ThongTinThietBi")]
        public Guid ThongTinThietBi_Id { get; set; }
        public ThongTinThietBi ThongTinThietBi { get; set; }
        [Range(0, 250)]
        public int SoLuong { get; set; }
        [ForeignKey("TinhTrangThietBi")]
        public Guid? TinhTrangThietBi_Id { get; set; }
        public TinhTrangThietBi TinhTrangThietBi { get; set; }
        [ForeignKey("DonViTinh")]
        public Guid? DonViTinh_Id { get; set; }
        public DonViTinh DonViTinh { get; set; }
        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
