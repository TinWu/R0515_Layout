﻿using DotWeb.WebApp;
using ProcCore.Business;
using System.Linq;
using System.Web.Mvc;

namespace DotWeb.Areas.Sys_Active.Controllers
{
    public class BannerController : BaseController
    {
        #region Action and function section
        public ActionResult Main()
        {
            ActionRun();
            return View();
        }

        #endregion

        #region ajax call section

        public string aj_Init()
        {
            using (var db0 = getDB0())
            {
                return defJSON(new
                {
                   // options_equipment_category = db0.Equipment_Category.OrderBy(x=>x.sort)
                });
            }
        }
        #endregion
    }
}