using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLKSProject.Business;

namespace QLKSProject.Controllers
{
    public class KhoiTaoDuLieuController : ApiController
    {
        [HttpGet]
        public bool TaoMoiCSDL()
        {
            bool b = false;
            using(KhoiTaoCSDL khoiTaoCSDL = new KhoiTaoCSDL())
            {
                b = khoiTaoCSDL.TaoCSDL();
            }
            return b;
        }
    }
}
