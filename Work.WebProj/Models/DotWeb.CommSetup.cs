using ProcCore.WebCore;
using System;

namespace DotWeb.CommSetup
{
    public static class CommWebSetup
    {
        private static string GetKeyValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
        public static string AutoLoginUser
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DEV_USER"];
            }
        }
        public static string AutoLoginPassword
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DEV_PWD"];
            }
        }
        public static string WebCookiesId
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["WebCookiesId"];
            }
        }
        public static string ManageDefCTR
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ManageDefCTR"];
            }
        }
        public static string UserLoginSource
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["UserLoginSource"];
            }
        }
        public static DateTime Expire
        {
            get
            {
                return DateTime.Parse(System.Configuration.ConfigurationManager.AppSettings["Expire"]);
            }
        }
        public static int MasterGridDefPageSize
        {
            get
            {
                return int.Parse(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            }
        }
        public static string Cookie_UserName
        {
            get
            {
                return "Cookie_UserName";
            }
        }
        public static string Cookie_LastLogin
        {
            get
            {
                return "Cookie_LastLogin";
            }
        }
        public static string Cookie_DepartmentId
        {
            get
            {
                return "Cookie_DepartmentId";
            }
        }
        public static string Cookie_DepartmentName
        {
            get
            {
                return "Cookie_DepartmentName";
            }
        }
        public static string CacheVer
        {
            get
            {
                return GetKeyValue("CacheVer");
            }
        }
        public static int Limit_Max_Apply_Days
        {
            get
            {
                return int.Parse(GetKeyValue("limit_max_apply_days"));
            }
        }
        public static int Chart_Canvas_Width
        {
            get
            {
                return int.Parse(GetKeyValue("Chart_Canvas_Width"));
            }
        }
        public static int Chart_Canvas_Height
        {
            get
            {
                return int.Parse(GetKeyValue("Chart_Canvas_Height"));
            }
        }
        public static int Chart_Canvas_EdgeColor
        {
            get
            {
                return Convert.ToInt32(GetKeyValue("Chart_Canvas_EdgeColor"), 16);
            }
        }
        public static int Chart_Canvas_BgColor
        {
            get
            {
                return Convert.ToInt32(GetKeyValue("Chart_Canvas_BgColor"), 16);
            }
        }
        public static int Chart_Diagram_Width
        {
            get
            {
                return int.Parse(GetKeyValue("Chart_Diagram_Width"));
            }
        }
        public static int Chart_Diagram_Height
        {
            get
            {
                return int.Parse(GetKeyValue("Chart_Diagram_Height"));
            }
        }
        public static int Chart_Title_BgColor
        {
            get
            {
                return Convert.ToInt32(GetKeyValue("Chart_Title_BgColor"), 16);
            }
        }
        public static int Chart_Title_FontColor
        {
            get
            {
                return Convert.ToInt32(GetKeyValue("Chart_Title_FontColor"), 16);
            }
        }
        public static int Chart_Title_FontSize
        {
            get
            {
                return Convert.ToInt32(GetKeyValue("Chart_Title_FontSize"));
            }
        }
        public static int Chart_Title_Height
        {
            get
            {
                return Convert.ToInt32(GetKeyValue("Chart_Title_Height"));
            }
        }
        public static string Chart_Title_FontFamily
        {
            get
            {
                return GetKeyValue("Chart_Title_FontFamily");
            }
        }
        public static string DB0_CodeString
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DB0"];
            }
        }
    }

    #region Image UpLoad Parma
    public static class ImageFileUpParm
    {
        public static ImageUpScope NewsBasicSingle
        {
            get
            {
                ImageUpScope imUp = new ImageUpScope() { KeepOriginImage = true, LimitCount = 50, LimitSize = 1024 * 1024 * 2 };
                imUp.Parm = new ImageSizeParm[] {
                    new ImageSizeParm(){ width=700,FolderName="Photo1"}
                };
                return imUp;
            }
        }

        public static ImageUpScope NewsBasicDouble
        {
            get
            {
                ImageUpScope imUp = new ImageUpScope() { KeepOriginImage = true, LimitCount = 10, LimitSize = 1024 * 1024 * 2 };
                imUp.Parm = new ImageSizeParm[] {
                    new ImageSizeParm(){ SizeFolder=350, width=350}
                };
                return imUp;
            }
        }

        public static ImageUpScope ProductShow
        {
            get
            {
                ImageUpScope imUp = new ImageUpScope() { KeepOriginImage = true, LimitCount = 10, LimitSize = 1024 * 1024 * 2 };
                imUp.Parm = new ImageSizeParm[] {
                    new ImageSizeParm(){ SizeFolder=232, width=232},
                    new ImageSizeParm(){ SizeFolder=800, width=800}
                };
                return imUp;
            }
        }

        public static ImageUpScope ProductList
        {
            get
            {
                ImageUpScope imUp = new ImageUpScope() { KeepOriginImage = true, LimitCount = 1, LimitSize = 1024 * 1024 * 2 };
                imUp.Parm = new ImageSizeParm[] {
                    new ImageSizeParm(){ SizeFolder=180, width=180},
                    new ImageSizeParm(){ SizeFolder=320, width=320}
                };
                return imUp;
            }
        }

    }
    public static class SysFileUpParm
    {
        public static FilesUpScope BaseLimit
        {
            get
            {
                FilesUpScope FiUp = new FilesUpScope() { LimitCount = 5, LimitSize = 1024 * 1024 * 256 };
                return FiUp;
            }
        }
    }
    #endregion
}