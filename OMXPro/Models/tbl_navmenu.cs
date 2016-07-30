using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OMXPro.Models
{
    public class tbl_navmenu
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string MenuName { get; set; }
        public string URL { get; set; }
        public Nullable<int> Order { get; set; }
    }
}