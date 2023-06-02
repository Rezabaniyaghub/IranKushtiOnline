using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ClassRoomModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name ="توضیحات")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public DateTime BirhDate { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public string Country { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public AgeRange AgeRange { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public int SchoolId { get; set; }

        [Required(ErrorMessage = "ورود {0} الزامی است")]
        [Display(Name = "توضیحات")]
        public string CreateDate { get; set; }

        public string SchoolName { get; set; }

        public List<SelectListItem> SchoolSelectList { get; set; }
    }
}