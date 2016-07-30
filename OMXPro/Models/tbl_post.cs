using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OMXPro.Models
{
    public class tbl_post
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> post_auid { get; set; }

        [Required(ErrorMessage ="Please Enter Post Title")]
        [Display(Name ="Article Title")]
        public string post_title { get; set; }
        public Nullable<System.DateTime> post_date { get; set; }
        public string year { get; set; }
        public string month { get; set; }

        [Display(Name = "Contents")]
        [UIHint("tinymce_Jquery_Full"), AllowHtml]
        public string post_content { get; set; }

       
        [Display(Name = "Article Summary")]
        [UIHint("tinymce_Jquery_Full"),AllowHtml]
        public string post_excerpt { get; set; }
        public string post_catid { get; set; }
        public Nullable<System.DateTime> post_modified { get; set; }

        [Display(Name = "Article Status")]
        public Nullable<int> post_status { get; set; }
        public Nullable<int> post_parent { get; set; }
        public Nullable<int> post_menu_order { get; set; }
        public string post_img { get; set; }
        public string post_img_title { get; set; }
        public string post_img_desc { get; set; }
        public string post_price { get; set; }
        public string post_attachment { get; set; }
        public string post_lang { get; set; }
    }
}