using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLKSProject.Models.Entities;

namespace QLKSProject.Business.NhanVien
{
    public class NhanVienBusiness:BaseBusiness
    {
        public List<DanhSachFileGui> LayDanhSachFileGui()
        {
            List<DanhSachFileGui> danhSachFileGuis = models.DanhSachFileGuis.Select(ds => ds).ToList();
            return danhSachFileGuis;
        }
    }
}