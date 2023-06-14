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
        [ForeignKey("Kho")]
        public Guid? Kho_Id { get; set; }
        public Kho Kho { get; set; }
        [ForeignKey("User")]
        public Guid? UserLap_Id { get; set; }
        public Guid? UserNhan_Id { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<DieuChuyenThietBi_Kho> DieuChuyenThietBi_Khos { get; set; }
        [NotMapped]
        public List<DieuChuyenThietBi_Kho> Lstkho { get; set; }
        public DateTime NgayDieuChuyen { get; set; }

    }
}
