using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class DieuChuyenThietBi:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaDieuChuyen { get; set; }
        /*        [JsonIgnore]
                public virtual ICollection<DieuChuyenBanGiao> dieuChuyenBanGiao { get; set; }
                [NotMapped]
                public List<DieuChuyenBanGiao> Lstdcbg { get; set; }*/
        [ForeignKey("BanGiaoTB")]
        public Guid? BanGiaoTB_Id { get; set; }
        public Guid? UserDieuChuyen_Id { get; set; }
        public ApplicationUser UserDieuChuyen { get; set; }
        [ForeignKey("DonVi")]
        public Guid? DonVi_Id { get; set; }
        public Guid? User_Id { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime NgayDieuChuyen { get; set; }
    }
}
