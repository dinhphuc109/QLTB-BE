using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class BanGiao_NguoiNhan: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("BanGiaoTB")]
        public Guid BanGiaoTB_Id { get; set; }
        public BanGiaoTB BanGiaoTB { get; set; }
        [ForeignKey("User")]
        public Guid User_Id { get; set; }
        public ApplicationUser User { get; set; }
    }
}
