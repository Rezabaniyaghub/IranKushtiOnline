using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public enum AgeRange
    {
        [Display(Name ="نونهالان")]
        Kidd=1,
        [Display(Name = "نوجوانان")]
        Tinnager =2,
        [Display(Name = "بزرگسالان")]
        Adalt =3
    }
}
