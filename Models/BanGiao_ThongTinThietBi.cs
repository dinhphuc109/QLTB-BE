using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class BanGiao_ThongTinThietBi: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("BanGiaoTB")]
        public Guid BanGiaoTB_Id { get; set; }
        public BanGiaoTB BanGiaoTB { get; set; }
        [ForeignKey("ThongTinThietBi")]
        public Guid ThongTinThietBi_Id { get; set; }
        public ThongTinThietBi ThongTinThietBi { get; set; }
    }
}
