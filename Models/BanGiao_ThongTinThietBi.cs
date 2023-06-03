using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class BanGiao_ThongTinThietBi: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("BanGiaoTB")]
        public Guid BanGiaoTB_Id { get; set; }
        public BanGiaoTB BanGiaoTB { get; set; }
        [ForeignKey("ThongTinThietBi")]
        public Guid ThongTinThietBi_Id { get; set; }
        public ThongTinThietBi ThongTinThietBi { get; set; }
        [Range(0, 250)]
        public int SoLuong { get; set; }
        [StringLength(250)]
        public string TinhTrangThietBi { get; set; }
        [ForeignKey("DonViTinh")]
        public Guid? DonViTinh_Id { get; set; }
        public DonViTinh DonViTinh { get; set; }
        //[Range(typeof(DateTime), "1/1/1900", "12/31/2099")]
        public DateTime NgayNhan { get; set; }
        [StringLength(250)]
        public string GhiChu { get; set; }

        [ForeignKey("Kho")]
        public Guid? Kho_Id { get; set; }
        public Kho Kho { get; set; }
    }
}
