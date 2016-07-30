using OMXPro.Models;
using System.Collections.Generic;

namespace OMXPro.ViewModels
{
    public class PostDataModel
    {
        public List<tbl_post> mPost { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
        public int NoOfPages { get; set; }
    }
}
