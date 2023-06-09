using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class ThanhLyThietBi: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaThanhLy { get; set; }
        [ForeignKey("User")]
        public Guid? User_Id { get; set; }
        public ApplicationUser User { get; set; }
        public virtual ICollection<ThanhLy_Kho> thanhLyKhos { get; set; }
        [NotMapped]
        public List<ThanhLy_Kho> Lsttlk { get; set; }
        [ForeignKey("Kho")]
        public Guid? Kho_Id { get; set; }
        public Kho Kho { get; set; }

        public DateTime ThoiGianThanhLy { get; set; }

    }
}
