using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class NguoiNhan_DieuChuyen: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("DieuChuyenThietBi")]
        public Guid DieuChuyenThietBi_Id { get; set; }
        public DieuChuyenThietBi DieuChuyenThietBi { get; set; }
        [ForeignKey("User")]
        public Guid User_Id { get; set; }
        public ApplicationUser User { get; set; }
    }
}
