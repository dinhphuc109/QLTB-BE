using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NETCORE3.Models
{
    public class ThongTinThietBi:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("DanhMucThietBi")]
        public Guid? DanhMucThietBI_Id { get; set; }
        public DanhMucThietBi DanhMucThietBi { get; set; }
        [ForeignKey("Domain")]
        public Guid? Domain_Id { get; set; }
        public Domain Domain { get; set; }
        [ForeignKey("NhaCungCap")]
        public Guid? NhaCungCap_Id { get; set; }
        public NhaCungCap NhaCungCap { get; set; }

        [StringLength(50)]
        public string SoSeri { get; set; }
        [StringLength(250)]
        public string ModelThietBi { get; set; }

        public DateTime ThoiGianBaoHanh { get; set; }
        [StringLength(250)]
        public string TinhTrangThietBi { get; set; }
        [ForeignKey("DonViTinh")]
        public Guid? DonViTinh_Id { get; set; }
        public DonViTinh DonViTinh { get; set; }
    }
}
