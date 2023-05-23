using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class KhoThongTinThietBi:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Kho")]
        public Guid Kho_Id { get; set; }
        public Kho Kho { get; set; }
        [ForeignKey("ThongTinThietBi")]
        public Guid ThongTinThietBi_Id { get; set; }
        public ThongTinThietBi ThongTinThietBi { get; set; }
    }
}
