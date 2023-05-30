using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCORE3.Models
{
    public class Loai_HangThietBi:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("HangThietBi")]
        public Guid HangThietBi_Id { get; set; }
        public HangThietBi HangThietBi { get; set; }
        [ForeignKey("LoaiThietBi")]
        public Guid LoaiThietBi_Id { get; set; }
        public LoaiThietBi LoaiThietBi { get; set; }
    }
}
