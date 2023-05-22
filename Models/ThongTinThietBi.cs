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
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaThongTinThietBi { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Tên bắt buộc")]
        public string TenThietBi { get; set; }
        public string CauHinh { get; set; }
        [ForeignKey("Domain")]
        public Guid? Domain_Id { get; set; }
        public Domain Domain { get; set; }
        [ForeignKey("NhaCungCap")]
        public Guid? NhaCungCap_Id { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        [ForeignKey("HangThietBi")]
        public Guid? HangThietBi_Id { get; set; }
        public HangThietBi HangThietBi { get; set; }
        public string SoSeri { get; set; }
        public string ModelThietBi { get; set; }
        public DateTime ThoiGianBaoHanh { get; set; }

        [JsonIgnore]
        public virtual ICollection<ChiTietLoaiThongTinThietBi> ChiTietLoaiThongTinThietBis { get; set; }
        [NotMapped]
        public List<ChiTietLoaiThongTinThietBi> LstLoai { get; set; }

    }
}
