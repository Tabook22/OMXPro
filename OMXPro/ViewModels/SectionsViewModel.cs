using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMXPro.ViewModels
{
    public class SectionsViewModel
    {
        public int secId { get; set; }
        public string sec_title { get; set; }
        public string sec_loc { get; set; }
        public string sec_desc { get; set; }
        public Nullable<int> sec_status { get; set; }
    }
}
