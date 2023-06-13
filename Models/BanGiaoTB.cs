using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class BanGiaoTB:Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaBanGIao { get; set; }
        [ForeignKey("User")]
        public Guid? UserGiao_Id { get; set; }
        public Guid? UserNhan_Id { get; set; }

        public ApplicationUser User { get; set; }
        [JsonIgnore]
        public virtual ICollection<BanGiao_ThongTinThietBi> banGiaoThongTinThietBis { get; set; }
        [NotMapped]
        public List<BanGiao_ThongTinThietBi> Lstbgtttb { get; set; }


    }
}
