using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class CBNV_DieuChuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("DieuChuyenNhanVien")]
        public Guid? DieuChuyenNhanVien_Id { get; set; }
        public DieuChuyenNhanVien DieuChuyenNhanVien { get; set; }
        [ForeignKey("User")]
        public Guid? User_Id { get; set; }
        public ApplicationUser User { get; set; }
        [StringLength(250)]
        public string GhiChu { get; set; }
    }
}
