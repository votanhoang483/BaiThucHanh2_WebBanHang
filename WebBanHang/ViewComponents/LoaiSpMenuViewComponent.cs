using Microsoft.AspNetCore.Mvc;
using WebBanHang.Models;
using WebBanHang.Repository;
namespace WebBanHang.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository loaiSp;
        public LoaiSpMenuViewComponent( ILoaiSpRepository loaiSpRepository)
        {
            loaiSp = loaiSpRepository;
        }

        public IViewComponentResult Invoke()
        {
            var loaisp = loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);

            return View(loaisp);
        }
    }
}
