using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class DieuChuyenBanGiao :Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("DieuChuyenThietBi")]
        public Guid DieuChuyenThietBi_Id { get; set; }
        public DieuChuyenThietBi DieuChuyenThietBi { get; set; }
        [ForeignKey("BanGiaoTB")]
        public Guid BanGiaoTB_Id { get; set; }
        public BanGiaoTB BanGiaoTB { get; set; }
    }
}
