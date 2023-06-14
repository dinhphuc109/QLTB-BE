using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class DieuChuyenThietBi_Kho : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("DieuChuyenThietBi")]
        public Guid DieuChuyenThietBi_Id { get; set; }
        public DieuChuyenThietBi DieuChuyenThietBi { get; set; }
        [ForeignKey("ThongTinThietBi")]
        public Guid ThongTinThietBi_Id { get; set; }
        public ThongTinThietBi ThongTinThietBi { get; set; }

        [Range(0, 250)]
        public int SoLuong { get; set; }
        [ForeignKey("TinhTrangThietBi")]
        public Guid? TinhTrangThietBi_Id { get; set; }
        public TinhTrangThietBi TinhTrangThietBi { get; set; }
        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
