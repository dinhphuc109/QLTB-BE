using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class DieuChuyenThietBi_Kho : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("DieuChuyenThietBi")]
        public Guid DieuChuyenThietBi_Id { get; set; }
        public DieuChuyenThietBi DieuChuyenThietBi { get; set; }
        [ForeignKey("Kho")]
        public Guid Kho_Id { get; set; }
        public Kho Kho { get; set; }
    }
}
