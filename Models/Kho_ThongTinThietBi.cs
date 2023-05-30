using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class Kho_ThongTinThietBi:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Kho")]
        public Guid Kho_Id { get; set; }
        public Kho Kho { get; set; }
        [ForeignKey("ThongTinThietBi")]
        public Guid ThongTinThietBi_Id { get; set; }
        public ThongTinThietBi ThongTinThietBi { get; set; }

        public int SoLuong { get; set; }
        public string TinhTrangThietBi { get; set; }
        [ForeignKey("DonViTinh")]
        public Guid? DonViTinh_Id { get; set; }
        public DonViTinh DonViTinh { get; set; }
    }
}
