using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NETCORE3.Models
{
  public class NhaCungCap : Auditable
  {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaNhaCungCap { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Tên bắt buộc")]
        public string TenNhaCungCap { get; set; }
        [StringLength(250)]
        public string NguoiLienHe { get; set; }
        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Số điện thoại chỉ được nhập số")]
        public string SoDienThoai { get; set; }
        [StringLength(250)]
        public string DiaChi { get; set; }
        [StringLength(250)]
        public string Email { get; set; }
    }
}