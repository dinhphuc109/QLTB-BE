﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static NETCORE3.Data.MyDbContext;

namespace NETCORE3.Models
{
    public class DieuChuyenNhanVien: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Mã bắt buộc")]
        public string MaDieuChuyen { get; set; }
        //người lập điều chuyển
        [ForeignKey("User")]
        public Guid? User_Id { get; set; }
        public ApplicationUser User { get; set; }
        public Guid? DonVi_Id { get; set; }
        public Guid? BoPhan_Id { get; set; }
        public Guid? ChucVu_Id { get; set; }
        public Guid? PhongBan_Id { get; set; }
        public Guid? DonViTraLuong_Id { get; set; }
        public Guid? DonViNew_Id { get; set; }
        public Guid? BoPhanNew_Id { get; set; }
        public Guid? ChucVuNew_Id { get; set; }
        public Guid? PhongBanNew_Id { get; set; }
        public Guid? DonViTraLuongNew_Id { get; set; }
        public DonVi DonVi { get; set; }
        public BoPhan BoPhan { get; set; }
        public ChucVu ChucVu { get; set; }
        public Phongban Phongban { get; set; }
        public DonViTraLuong DonViTraLuong { get; set; }
        public DonVi DonViNew { get; set; }
        public BoPhan BoPhanNew { get; set; }
        public ChucVu ChucVuNew { get; set; }
        public Phongban PhongbanNew { get; set; }
        public DonViTraLuong DonViTraLuongNew { get; set; }

        [JsonIgnore]
        public virtual ICollection<CBNV_DieuChuyen> cBNVDieuChuyens { get; set; }
        [NotMapped]
        public List<CBNV_DieuChuyen> Lstcbnvdc { get; set; }

        public DateTime NgayDieuChuyen { get; set; }
        public string TrangThai { get; set; }
        public bool XacNhan { get; set; }

    }
}
