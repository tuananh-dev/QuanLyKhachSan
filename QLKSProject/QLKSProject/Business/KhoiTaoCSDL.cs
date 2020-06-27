using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKSProject.Business
{
    public class KhoiTaoCSDL : BaseBusiness
    {
        #region Public Methods
        public bool TaoCSDL()
        {

            return true;
        }
        #endregion


        #region Private Methods
        private bool TaoPhong()
        {

            return true;
        }
        private bool TaoDichVu()
        {
            string[] lstTenDichVu = { "An Sang", "Thue Xe", };
            return true;
        }
        #endregion

    }
}