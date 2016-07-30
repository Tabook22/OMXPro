using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMXPro.ViewModels
{
    public class ImageViewModel
    {
        [Key]
        public int imgid { get; set; }
        public string imgfolder { get; set; }
        public string imgurl_lg { get; set; }
        public string imgurl_sm { get; set; }
        public string imgurl_th { get; set; }
        public string imgfullurl { get; set; }
        public string imgtitle { get; set; }
        public string imgdesc { get; set; }
        public Nullable<int> imgpid { get; set; }
        public string imglink { get; set; }
        public string imgrole { get; set; }
        public string imgyear { get; set; }
        public Nullable<System.DateTime> imgdate { get; set; }
        public Nullable<int> imgshow { get; set; }
        public string imgw { get; set; }
        public string imgh { get; set; }
    }
}