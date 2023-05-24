using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SchoolModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public string Address { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public string CreateDate { get; set; }
    }
}
