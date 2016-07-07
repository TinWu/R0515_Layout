using System.Web.Optimization;
using System.Web.Optimization.React;

namespace DotWeb.AppStart
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JScript

            string[] commFile = new string[] {
                "~/ScriptsTSDef/dynScript/defData.js",
                "~/Scripts/jquery/jquery-2.1.1.js",
                "~/Scripts/angular/angular.js",
                "~/Scripts/angular/angular-animate.js",
                "~/Scripts/angular/angular-route.js",
                "~/Scripts/angular/i18n/angular-locale_zh-tw.js",
                "~/Scripts/angular-plugging/signalr-hub.js",
                "~/Scripts/angular-plugging/toaster.js",
                "~/Scripts/angular-plugging/ui-bootstrap-tpls-0.11.2.js",
                "~/ScriptsTSDef/commfunc.js",
                "~/ScriptsTSDef/commangular.js",
                "~/Scripts/BrowerInfo.js",
            };

            string[] cusFileUpLoad = new string[] {
                "~/ScriptsTSDef/dynScript/defData.js",
                "~/Scripts/angular-plugging/angular-file-upload/angular-file-upload-html5-shim.js",
                "~/Scripts/jquery/jquery-2.1.1.js",
                "~/Scripts/angular/angular.js",
                "~/Scripts/angular-plugging/angular-file-upload/angular-file-upload.js",
                "~/Scripts/angular/angular-animate.js",
                "~/Scripts/angular/angular-route.js",
                "~/Scripts/angular/i18n/angular-locale_zh-tw.js",
                "~/Scripts/angular-plugging/signalr-hub.js",
                "~/Scripts/angular-plugging/toaster.js",
                "~/Scripts/angular-plugging/ui-bootstrap-tpls-0.11.2.js",
                "~/ScriptsTSDef/commfunc.js",
                "~/ScriptsTSDef/commangular.js",
                "~/Scripts/BrowerInfo.js"
            };

            string[] commReactFile = new string[] {
                "~/ScriptsTSDef/dynScript/defData.js",
                "~/Scripts/moment/moment.js",
                "~/Scripts/moment/locale/zh-tw.js",
                "~/Scripts/toastr.js",
                "~/Scripts/jquery/jquery-2.1.3.js",
                "~/Scripts/react/react-with-addons.js",
                "~/Scripts/react/LinkedStateMixin.js",
                "~/ScriptsTSDef/commfunc.js",
                "~/ScriptsJSX/comm.jsx",
                "~/Scripts/BrowerInfo.js"
            };


            string[] commReacWebWWW = new string[] {
                "~/Scripts/codrops/classie.js",
                "~/Scripts/codrops/modalEffects.js",
                "~/ScriptsTSDef/dynScript/defData.js",
                "~/Scripts/moment/moment.js",
                "~/Scripts/moment/locale/zh-tw.js",
                "~/Scripts/react/react-with-addons.js",
                "~/ScriptsTSDef/commfunc.js",
                "~/ScriptsJSX/comm.jsx",
                "~/ScriptsTSDef/commwww.js",
                "~/Scripts/BrowerInfo.js"
            };

            bundles.Add(new JsxBundle("~/loginRct")
            .Include(commReactFile)
            .Include("~/ScriptsJSX/login.jsx")
            );

            #region Sys_Base
            bundles.Add(new ScriptBundle("~/login")
            .Include(commFile)
            .Include("~/ScriptsCtrl/login.js")
            );
            bundles.Add(new ScriptBundle("~/rolesCtr")
                .Include(commFile)
                .Include("~/ScriptsCtrl/rolesCtr")
                );
            bundles.Add(new ScriptBundle("~/usersCtr")
                .Include(commFile)
                .Include("~/ScriptsCtrl/usersCtr.js")
                );

            bundles.Add(new ScriptBundle("~/changepasswordCtr")
                .Include(commFile)
                .Include("~/ScriptsCtrl/users_changepassword.js")
                );
            #endregion
            #region Sys_Active
            bundles.Add(new JsxBundle("~/newsRct")
            .Include(commReactFile)
            .Include("~/Scripts/datetimepicker/bootstrap-datetimepicker.js")
            .Include("~/Scripts/SimpleAjaxUploader.js")
            .Include("~/ScriptsJSXM/news_dataM.jsx")
            );

            bundles.Add(new JsxBundle("~/activeRct")
            .Include(commReactFile)
            .Include("~/Scripts/datetimepicker/bootstrap-datetimepicker.js")
            .Include("~/Scripts/SimpleAjaxUploader.js")
            .Include("~/Scripts/Sortable.js")
            .Include("~/Scripts/react-sortable-mixin.js")
            .Include("~/ScriptsJSXM/activeM.jsx")
            );

            bundles.Add(new JsxBundle("~/memberRct")
            .Include(commReactFile)
            .Include("~/Scripts/datetimepicker/bootstrap-datetimepicker.js")
            .Include("~/Scripts/SimpleAjaxUploader.js")
            .Include("~/Scripts/Sortable.js")
            .Include("~/Scripts/react-sortable-mixin.js")
            .Include("~/ScriptsJSXM/memberM.jsx")
            );

            bundles.Add(new JsxBundle("~/memberprintRct")
            .Include(commReactFile)
            .Include("~/Scripts/datetimepicker/bootstrap-datetimepicker.js")
            .Include("~/ScriptsJSXM/member_printM.jsx")
            );

            bundles.Add(new JsxBundle("~/documentRct")
            .Include(commReactFile)
            .Include("~/Scripts/datetimepicker/bootstrap-datetimepicker.js")
            .Include("~/Scripts/SimpleAjaxUploader.js")
            .Include("~/ScriptsJSXM/documentM.jsx")
            );
            #endregion
            #region Web WWW

            bundles.Add(new JsxBundle("~/homeWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/homeW.jsx")
            );

            bundles.Add(new JsxBundle("~/news_listWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/news_listW.jsx")
            );

            bundles.Add(new JsxBundle("~/news_contentWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/news_contentW.jsx")
            );

            bundles.Add(new JsxBundle("~/actities_listWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/actities_listW.jsx")
            );

            bundles.Add(new JsxBundle("~/actities_contentWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/actities_contentW.jsx")
            );

            bundles.Add(new JsxBundle("~/member_listWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/member_listW.jsx")
            );

            bundles.Add(new JsxBundle("~/member_contentWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/member_contentW.jsx")
            );

            bundles.Add(new JsxBundle("~/business_listWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/business_listW.jsx")
            );

            bundles.Add(new JsxBundle("~/document_listWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/document_listW.jsx")
            );

            bundles.Add(new JsxBundle("~/document_contentWWW")
            .Include(commReacWebWWW)
            .Include("~/ScriptsJSX/document_contentW.jsx")
            );

            #endregion
            #endregion

            #region CSS
            bundles.Add(new StyleBundle("~/_Code/CSS/CSS")
            .Include(
            "~/_Code/CSS/css/page.css",
            "~/_Code/CSS/toaster.css"
            ));
            #endregion
            //BundleTable.EnableOptimizations = false;
        }
    }
}
