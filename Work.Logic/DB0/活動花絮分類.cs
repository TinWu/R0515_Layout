//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProcCore.Business.DB0
{
    using System;
    using System.Collections.Generic;
    
    using Newtonsoft.Json;
    public partial class 活動花絮分類 : BaseEntityTable
    {
        public 活動花絮分類()
        {
            this.活動花絮主檔 = new HashSet<活動花絮主檔>();
        }
    
        public int 流水號 { get; set; }
        public Nullable<int> 分類編號 { get; set; }
        public string 分類名稱 { get; set; }
        public string 分類說明 { get; set; }
        public Nullable<float> 排序 { get; set; }
    
    	[JsonIgnore]
        public virtual ICollection<活動花絮主檔> 活動花絮主檔 { get; set; }
    }
}
