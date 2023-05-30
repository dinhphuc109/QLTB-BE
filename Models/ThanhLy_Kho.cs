using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class ThanhLy_Kho : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("Kho")]
        public Guid Kho_Id { get; set; }
        public Kho Kho { get; set; }
        [ForeignKey("ThanhLyThietBi")]
        public Guid ThanhLyThietBi_Id { get; set; }
        public ThanhLyThietBi ThanhLyThietBi { get; set; }
    }
}
