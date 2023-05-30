using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class Kho:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("DanhMucKho")]
        public Guid? DanhMucKho_Id { get; set; }
        public DanhMucKho DanhMucKho { get; set; }
/*        [JsonIgnore]
        public virtual ICollection<KhoLoaiThietBi> khoLoaiThietBis { get; set; }
        [NotMapped]
        public List<KhoLoaiThietBi> LstLoai { get; set; }*/
        [JsonIgnore]
        public virtual ICollection<Kho_ThongTinThietBi> khoThongTinThietBis { get; set; }
        [NotMapped]
        public List<Kho_ThongTinThietBi> LstKhotttb { get; set; }

        [ForeignKey("DonVi")]
        public Guid? DonVi_Id { get; set; }
        public DonVi DonVi { get; set; }
        [ForeignKey("User")]
        public Guid? User_Id { get; set; }
        public ApplicationUser User { get; set; }

    }
}
