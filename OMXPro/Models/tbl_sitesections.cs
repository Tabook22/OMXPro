using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMXPro.Models
{
    public class tbl_siteSection
    {
        [Key]
        public int secId { get; set; }
        public string sec_title { get; set; }
        public string sec_loc { get; set; }
        public string sec_desc { get; set; }
        public Nullable<int> sec_status { get; set; }
    }
}