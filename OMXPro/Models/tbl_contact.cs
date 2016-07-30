using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMXPro.Models
{
    public class tbl_contact
    {
        [Key]
        public int id { get; set; }
        public Nullable<System.DateTime> GDate { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Name:")]
        public string GName { get; set; }
        public string GAddress { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [Display(Name = "Email Address:")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string GEmail { get; set; }

        public string GSubject { get; set; }
        public string GData { get; set; }
    }
}
