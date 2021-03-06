﻿using DotWeb.Helpers;
using ProcCore.Business.DB0;
using ProcCore.HandleResult;
using ProcCore.WebCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DotWeb.Api
{
    public class ActiveController : ajaxApi<活動花絮主檔, q_活動花絮>
    {
        public async Task<IHttpActionResult> Get(int id)
        {
            using (db0 = getDB0())
            {
                item = await db0.活動花絮主檔.FindAsync(id);
                r = new rAjaxGetData<活動花絮主檔>() { data = item };
            }

            return Ok(r);
        }
        public IHttpActionResult Get([FromUri]q_活動花絮 q)
        {
            #region 連接BusinessLogicLibary資料庫並取得資料

            using (db0 = getDB0())
            {
                var items = (from x in db0.活動花絮主檔
                             orderby x.活動日期 descending
                             select new m_活動花絮主檔()
                             {
                                 流水號 = x.流水號,
                                 標題 = x.標題,
                                 活動日期 = x.活動日期,
                                 顯示狀態Flag = x.顯示狀態Flag,
                                 分類 = x.分類,
                                 排序 = x.排序
                             });

                if (q.title != null)
                {
                    items = items.Where(x => x.標題.Contains(q.title));
                }

                int page = (q.page == null ? 1 : (int)q.page);
                int startRecord = PageCount.PageInfo(page, this.defPageSize, items.Count());

                var resultItems = items.Skip(startRecord).Take(this.defPageSize).ToList();

                return Ok(new GridInfo<m_活動花絮主檔>()
                {
                    rows = resultItems,
                    total = PageCount.TotalPage,
                    page = PageCount.Page,
                    records = PageCount.RecordCount,
                    startcount = PageCount.StartCount,
                    endcount = PageCount.EndCount
                });
            }
            #endregion
        }
        public async Task<IHttpActionResult> Put([FromBody]活動花絮主檔 md)
        {
            ResultInfo rAjaxResult = new ResultInfo();
            try
            {
                db0 = getDB0();

                item = await db0.活動花絮主檔.FindAsync(md.流水號);

                item.標題 = md.標題;
                item.活動日期 = md.活動日期;
                item.顯示狀態Flag = md.顯示狀態Flag;
                item.排序 = md.排序;

                var details = item.活動花絮內容;

                foreach (var detail in details)
                {
                    var md_detail = md.活動花絮內容.First(x => x.流水號 == detail.流水號);
                    detail.標題 = md_detail.標題;
                    detail.排序 = md_detail.排序;
                    detail.活動日期 = md_detail.活動日期;
                    detail.顯示狀態Flag = md_detail.顯示狀態Flag;
                }

                var add_detail = md.活動花絮內容.Where(x => x.edit_state == EditState.Insert);
                foreach (var detail in add_detail)
                {
                    detail.流水號 = GetNewId();
                    details.Add(detail);
                }

                await db0.SaveChangesAsync();
                rAjaxResult.result = true;
            }
            catch (Exception ex)
            {
                rAjaxResult.result = false;
                rAjaxResult.message = ex.ToString();
            }
            finally
            {
                db0.Dispose();
            }
            return Ok(rAjaxResult);
        }
        public async Task<IHttpActionResult> Post([FromBody]活動花絮主檔 md)
        {
            md.流水號 = GetNewId(ProcCore.Business.CodeTable.Base);
            md.分類 = 1;

            ResultInfo rAjaxResult = new ResultInfo();
            if (!ModelState.IsValid)
            {
                rAjaxResult.message = ModelStateErrorPack();
                rAjaxResult.result = false;
                return Ok(rAjaxResult);
            }

            try
            {
                #region working a
                db0 = getDB0();

                db0.活動花絮主檔.Add(md);
                await db0.SaveChangesAsync();

                rAjaxResult.result = true;
                rAjaxResult.id = md.流水號;
                return Ok(rAjaxResult);
                #endregion
            }
            catch (Exception ex)
            {
                rAjaxResult.result = false;
                rAjaxResult.message = ex.Message;
                return Ok(rAjaxResult);
            }
            finally
            {
                db0.Dispose();
            }
        }
        public async Task<IHttpActionResult> Delete([FromUri]int[] ids)
        {
            ResultInfo rAjaxResult = new ResultInfo();
            try
            {
                db0 = getDB0();

                foreach (var id in ids)
                {
                    var subitem = db0.活動花絮內容.Where(x => x.主檔流水號 == id);
                    db0.活動花絮內容.RemoveRange(subitem);



                    item = new 活動花絮主檔() { 流水號 = id };
                    db0.活動花絮主檔.Attach(item);
                    db0.活動花絮主檔.Remove(item);

                    

                }

                await db0.SaveChangesAsync();

                rAjaxResult.result = true;
                return Ok(rAjaxResult);
            }
            catch (Exception ex)
            {
                rAjaxResult.result = false;
                rAjaxResult.message = ex.Message;
                return Ok(rAjaxResult);
            }
            finally
            {
                db0.Dispose();
            }
        }
    }
}
