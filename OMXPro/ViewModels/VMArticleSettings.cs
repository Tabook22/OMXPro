using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMXPro.ViewModels
{
    public class VMArticleSettings
    {
        //articles
        public int Id { get; set; }
        public Nullable<System.DateTime> a_date { get; set; }
        public string a_title { get; set; }
        public string a_source { get; set; }
        public string a_desc { get; set; }
        public string a_link { get; set; }
        public string a_img { get; set; }
        public string a_type { get; set; }
        public string a_mediatype { get; set; }
        public string a_meidatype_link { get; set; }
        public Nullable<int> a_order { get; set; }
        public string a_loc { get; set; }
        public string a_status { get; set; }
        //sections
        public int secId { get; set; }
        public string sec_title { get; set; }

    }
}