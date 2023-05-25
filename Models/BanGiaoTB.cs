using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class BanGiaoTB:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaBanGIao { get; set; }
        [ForeignKey("User")]
        public Guid? User_Id { get; set; }
        public ApplicationUser User { get; set; }
        [JsonIgnore]
        public virtual ICollection<BanGiaoNguoiNhan> banGiaoNguoiNhans { get; set; }
        [NotMapped]
        public List<BanGiaoNguoiNhan> Lstbgnn { get; set; }
        [JsonIgnore]
        public virtual ICollection<BanGiaoThongTinThietBi> banGiaoThongTinThietBis { get; set; }
        [NotMapped]
        public List<BanGiaoThongTinThietBi> Lstbgtttb { get; set; }
        public int SoLuong { get; set; }
        public string TinhTrangThietBi { get; set; }
        [ForeignKey("DonViTinh")]
        public Guid? DonViTinh_Id { get; set; }
        public DonViTinh DonViTinh { get; set; }
        public DateTime NgayNhan { get; set; }
        public string GhiChu { get; set; }

    }
}
