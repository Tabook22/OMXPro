using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OMXPro.Models;

namespace OMXPro.ViewModels
{
   public class VMHeader
 {

        //site logo
        public string imgurl_lg { get; set; }
        public string imgtitle { get; set; }
        public string imglink { get; set; }

        //site socials
        public string Name { get; set; }
        public string Link { get; set; }
        public Nullable<int> Order { get; set; }
        public string img { get; set; }

    }
}