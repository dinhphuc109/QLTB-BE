using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NETCORE3.Models
{
    public class HangThietBi:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaHangThietBi { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Tên bắt buộc")]
        public string TenHang { get; set; }
        [ForeignKey("HeThong")]
        public Guid? HeThong_Id { get; set; }
        public HeThong HeThong { get; set; }
        [JsonIgnore]
        public virtual ICollection<Loai_HangThietBi> loaiHangThietBis { get; set; }
        [NotMapped]
        public List<Loai_HangThietBi> LstLoai { get; set; }

    }
}
