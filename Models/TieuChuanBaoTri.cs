using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class TieuChuanBaoTri : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaTieuChuanBaoTri { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Tên bắt buộc")]
        public string TenTieuChuanBaoTri { get; set; }
        public DateTime ThoiGianTieuChuanBaoTri { get; set; }
        [StringLength(250)]
        public string QuyDinh_TaiLieuHuongDan { get; set; }
    }
}
