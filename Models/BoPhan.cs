using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NETCORE3.Models
{
  public class BoPhan : Auditable
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [StringLength(50)]
    [Required(ErrorMessage = "Mã bắt buộc")]
    public string MaBoPhan { get; set; }
    [StringLength(250)]
    [Required(ErrorMessage = "Tên bắt buộc")]
    public string TenBoPhan { get; set; }
    [ForeignKey("Phòng ban")]
    public Guid? PhongBan_Id {get; set;}
    public Phongban Phongban  {get; set;}
  }
}