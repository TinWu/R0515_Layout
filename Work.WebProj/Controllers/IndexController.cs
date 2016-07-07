using System.Web.Mvc;
using ProcCore.Business.DB0;
using System.Collections.Generic;
using System.Linq;

namespace DotWeb.Controllers
{
    public class IndexController : WebFrontController
    {
        public ActionResult Index()
        {
            ViewBag.IsFirstPage = true;

            using (db0 = getDB0())
            {
                var m = new WebInfo()
                { 
                    News = db0.最新消息.Where(x=>x.顯示狀態Flag).OrderByDescending(x=>x.活動日期).Take(8).ToList(),
                    Document = db0.文件管理.Where(x=>x.顯示狀態Flag).OrderByDescending(x=>x.活動日期).Take(8).ToList()
                };
                return View(m);
            };
        }
    }


}
