using ProcCore.Business.DB0;
using ProcCore.HandleResult;
using ProcCore.WebCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.IO;

namespace DotWeb.Api
{
    public class GetActionController : BaseApiController
    {
        public GetActionController()
        {

        }
        public IHttpActionResult GetNewsWWW(int? y, int? page, string keyword)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.最新消息
                    .Where(x => x.顯示狀態Flag)
                    .OrderByDescending(x => x.活動日期)
                    .Select(x => new { x.流水號, x.活動日期, x.標題 });

                if (y != null)
                {
                    items = items.Where(x => x.活動日期.Year == y);
                }

                if (keyword != null)
                {
                    items = items.Where(x => x.標題.Contains(keyword));
                }

                var nowpage = page == null ? 1 : (int)page;
                int startRecord = PageCount.PageInfo(nowpage, 10, items.Count());
                var resultItems = items.Skip(startRecord).Take(10);

                var GridInfo = new
                {
                    rows = resultItems.ToList(),
                    total = PageCount.TotalPage,
                    page = PageCount.Page,
                    records = PageCount.RecordCount,
                    startcount = PageCount.StartCount,
                    endcount = PageCount.EndCount
                };

                return Ok(GridInfo);
            }
            #endregion
        }
        public IHttpActionResult GetActiveWWW(int? page)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.活動花絮主檔
                    .Where(x => x.顯示狀態Flag)
                    .OrderByDescending(x => x.活動日期)
                    .Select(x => new ccc
                    {
                        流水號 = x.流水號,
                        活動日期 = x.活動日期,
                        標題 = x.標題,
                        活動花絮內容 = x.活動花絮內容.Select(y => new { y.流水號, y.標題 })
                    });

                var nowpage = page == null ? 1 : (int)page;
                int startRecord = PageCount.PageInfo(nowpage, 6, items.Count());
                var resultItems = items.Skip(startRecord).Take(6);

                var GridInfo = new
                {
                    rows = resultItems.ToList(),
                    total = PageCount.TotalPage,
                    page = PageCount.Page,
                    records = PageCount.RecordCount,
                    startcount = PageCount.StartCount,
                    endcount = PageCount.EndCount
                };

                foreach (var item in GridInfo.rows)
                {
                    item.imgsrc = GetImg("Activities", "Activities", item.流水號, "photo1");
                }

                return Ok(GridInfo);
            }
            #endregion
        }
        public IHttpActionResult GetActiveAllWWW(string searchKey, int? y)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.活動花絮主檔
                    .Where(x => x.顯示狀態Flag)
                    .OrderByDescending(x => x.活動日期)
                    .Select(x => new ccc
                    {
                        流水號 = x.流水號,
                        活動日期 = x.活動日期,
                        標題 = x.標題,
                        活動花絮內容 = x.活動花絮內容.Where(w => w.顯示狀態Flag)
                        .OrderByDescending(w => w.排序).Select(w => new { w.流水號, w.標題 })
                    });

                if (searchKey != null)
                {
                    items = items.Where(x => x.標題.Contains(searchKey));
                }

                if (y != null)
                {
                    items = items.Where(x => x.活動日期.Year == y);
                }
                var GridInfo = new
                {
                    rows = items.ToList(),
                    total = PageCount.TotalPage,
                    page = PageCount.Page,
                    records = PageCount.RecordCount,
                    startcount = PageCount.StartCount,
                    endcount = PageCount.EndCount
                };

                foreach (var item in GridInfo.rows)
                {
                    item.imgsrc = GetImg("Activities", "Activities", item.流水號, "photo1");
                }

                return Ok(GridInfo);
            }
            #endregion
        }
        public IHttpActionResult GetShareWWW(int? page)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.文件管理
                    .Where(x => x.顯示狀態Flag && x.分類 == 1)
                    .OrderByDescending(x => x.活動日期)
                    .Select(x => new { x.流水號, x.活動日期, x.標題 });

                var nowpage = page == null ? 1 : (int)page;
                int startRecord = PageCount.PageInfo(nowpage, 6, items.Count());
                var resultItems = items.Skip(startRecord).Take(6);

                var GridInfo = new
                {
                    rows = resultItems.ToList(),
                    total = PageCount.TotalPage,
                    page = PageCount.Page,
                    records = PageCount.RecordCount,
                    startcount = PageCount.StartCount,
                    endcount = PageCount.EndCount
                };

                return Ok(GridInfo);
            }
            #endregion
        }
        public IHttpActionResult GetMeetingWWW(int? page)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.文件管理
                    .Where(x => x.顯示狀態Flag && x.分類 == 3)
                    .OrderByDescending(x => x.活動日期)
                    .Select(x => new { x.流水號, x.活動日期, x.標題 });

                var nowpage = page == null ? 1 : (int)page;
                int startRecord = PageCount.PageInfo(nowpage, 6, items.Count());
                var resultItems = items.Skip(startRecord).Take(6);

                var GridInfo = new
                {
                    rows = resultItems.ToList(),
                    total = PageCount.TotalPage,
                    page = PageCount.Page,
                    records = PageCount.RecordCount,
                    startcount = PageCount.StartCount,
                    endcount = PageCount.EndCount
                };

                return Ok(GridInfo);
            }
            #endregion
        }
        public IHttpActionResult GetDocWWW(int? page)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.文件管理
                    .Where(x => x.顯示狀態Flag && x.分類 == 4)
                    .OrderByDescending(x => x.活動日期)
                    .Select(x => new { x.流水號, x.活動日期, x.標題 });

                var nowpage = page == null ? 1 : (int)page;
                int startRecord = PageCount.PageInfo(nowpage, 6, items.Count());
                var resultItems = items.Skip(startRecord).Take(6);

                var GridInfo = new
                {
                    rows = resultItems.ToList(),
                    total = PageCount.TotalPage,
                    page = PageCount.Page,
                    records = PageCount.RecordCount,
                    startcount = PageCount.StartCount,
                    endcount = PageCount.EndCount
                };

                return Ok(GridInfo);
            }
            #endregion
        }
        public IHttpActionResult GetDocContent(int id)
        {
            #region
            using (db0 = getDB0())
            {
                var items = db0.文件管理.Find(id);
                return Ok(items);
            }
            #endregion
        }
        public IHttpActionResult GetNewsContentWWW(int id)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.最新消息.Find(id);
                return Ok(items);
            }
            #endregion
        }
        public IHttpActionResult GetActiveContentWWW(int id)
        {
            #region
            using (db0 = getDB0())
            {
                var items = db0.活動花絮主檔.Find(id);
                items.IContext = db0.活動花絮內容
                    .Where(x => x.主檔流水號 == id)
                    .OrderByDescending(x => x.排序)
                    .Select(x => new 活動花絮內容L
                    {
                        流水號 = x.流水號,
                        標題 = x.標題,
                        活動日期 = x.活動日期,
                        顯示狀態Flag = x.顯示狀態Flag,
                        排序 = (float)x.排序
                    }
                    ).ToList();
                string tplPath = "~/_Upload/Activities/ActivitiesDetail";
                var imgPath = HttpContext.Current.Server.MapPath(tplPath);
                foreach (var item in items.IContext)
                {
                    var imgIdPath = imgPath + "\\" + item.流水號;
                    if (Directory.Exists(imgIdPath))
                    {
                        var getFiles = Directory.EnumerateFiles(imgIdPath)
                            .Where(x => x.EndsWith("jpg") || x.EndsWith("jpeg") || x.EndsWith("png"));
                        IList<string> collectFile = new List<string>();

                        foreach (var file in getFiles)
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            collectFile.Add(Url.Content(tplPath + "\\" + item.流水號 + "\\" + fileInfo.Name));
                        }

                        if (Directory.Exists(imgIdPath + "\\Photo1"))
                        {
                            getFiles = Directory.EnumerateFiles(imgIdPath + "\\Photo1")
                                .Where(x => x.EndsWith("jpg") || x.EndsWith("jpeg") || x.EndsWith("png"));

                            foreach (var file in getFiles)
                            {
                                FileInfo fileInfo = new FileInfo(file);
                                collectFile.Add(Url.Content(tplPath + "\\" + item.流水號 + "\\Photo1\\" + fileInfo.Name));
                            }
                        }
                        item.imgsrc = collectFile.ToArray();
                    }
                }

                return Ok(items);
            }
            #endregion
        }
        public IHttpActionResult GetBusinessWWW(int? page)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.會員產品
                    .Where(x => x.顯示狀態Flag)
                    .OrderByDescending(x => x.活動日期)
                    .Select(x => new ccd
                    {
                        流水號 = x.流水號,
                        產品名稱 = x.產品名稱,
                        產品特色 = x.產品特色,
                        點閱率 = (int)x.點閱率,
                        姓名 = x.會員.姓名,
                        mid = x.會員.流水號
                    });

                var nowpage = page == null ? 1 : (int)page;
                int startRecord = PageCount.PageInfo(nowpage, 15, items.Count());
                var resultItems = items.Skip(startRecord).Take(15);

                var GridInfo = new
                {
                    rows = resultItems.ToList(),
                    total = PageCount.TotalPage,
                    page = PageCount.Page,
                    records = PageCount.RecordCount,
                    startcount = PageCount.StartCount,
                    endcount = PageCount.EndCount
                };

                foreach (var item in GridInfo.rows)
                {
                    item.imgsrc = GetImg("Member", "Product", item.流水號, "photo1");
                }

                return Ok(GridInfo);
            }
            #endregion
        }
        public IHttpActionResult GetMemberContentWWW(int id)
        {
            #region
            using (db0 = getDB0())
            {
                var items = db0.會員.Find(id);
                items.imgsrc_peoson = GetImg("Member", "Member", id, "Photo1");
                return Ok(items);
            }
            #endregion
        }
        public IHttpActionResult GetProductWWW(int id)
        {
            #region

            using (db0 = getDB0())
            {
                var items = db0.會員產品
                    .OrderByDescending(x=>x.排序)
                    .Where(x => x.會員流水號 == id).ToList();
                foreach (var item in items)
                {
                    item.imgsrc = GetImg("Member", "Product", item.流水號, "Photo1");
                }
                return Ok(items);
            }
            #endregion
        }
        public IHttpActionResult GetMemberWWW()
        {
            #region
            using (db0 = getDB0())
            {
                var items = db0.會員.Where(x => x.顯示狀態Flag)
                    .Where(x => x.入會日期 > new DateTime(1972, 1, 1))
                    .GroupBy(x => x.入會日期.Year)
                    .Select(x => new { x.Key, Item = x.Select(y => new { y.姓名 }) })
                    .OrderByDescending(x => x.Key)
                    .ToList();

                return Ok(items);
            }
            #endregion
        }
        private string GetImg(string name1, string name2, int id, string kind)
        {
            string tplPath = "~/_Upload/" + name1 + "/" + name2 + "/" + id + "/" + kind;
            var imgPath = HttpContext.Current.Server.MapPath(tplPath);
            if (Directory.Exists(imgPath))
            {
                var getFiles = Directory.EnumerateFiles(imgPath)
                    .Where(x => x.EndsWith("jpg") || x.EndsWith("jpeg") || x.EndsWith("png"))
                    .FirstOrDefault();

                if (getFiles != null)
                {
                    FileInfo fileInfo = new FileInfo(getFiles);
                    return Url.Content(tplPath + "\\" + fileInfo.Name);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
    class ccc
    {
        public int 流水號 { get; set; }
        public DateTime 活動日期 { get; set; }
        public string 標題 { get; set; }
        public object 活動花絮內容 { get; set; }
        public string imgsrc { get; set; }
    }

    class ccd
    {
        public int 流水號 { get; set; }
        public string 產品名稱 { get; set; }
        public string 產品特色 { get; set; }
        public int 點閱率 { get; set; }
        public string 姓名 { get; set; }
        public int mid { get; set; }
        public string imgsrc { get; set; }
    }
}
