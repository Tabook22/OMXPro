using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMXPro.ViewModelss
{
    public class Articles
    {
        [Required(ErrorMessage = "الرجاء كتابة رابط المقالة أو الخبر")]
        [Display(Name = "رابط المصدر")]
        public string a_link { get; set; }

         [Required(ErrorMessage = "الرجاء كتابة عنوان المقالة أو الخبر")]
        [Display(Name = "العنوان")]
        public string a_title { get; set; }

        [Display(Name="وصف مختصر")]
        public string a_desc { get; set; }

        [Display(Name = "الترتيب")]
        public Nullable<int> a_order { get; set; }

        [Display(Name="رابط الصورة")]
        public string a_img { get; set; }

        [Display(Name = "الفئة / الموقع")]
        public string a_loc { get; set; }

        [Display(Name = "الحالة")]
        public string a_status { get; set; }
    }

    
}
