using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class KhoLoaiThietBi:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Kho")]
        public Guid Kho_Id { get; set; }
        public Kho Kho { get; set; }
        [ForeignKey("LoaiThietBi")]
        public Guid LoaiThietBi_Id { get; set; }
        public LoaiThietBi LoaiThietBi { get; set; }
    }
}
