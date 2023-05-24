using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public enum Gender
    {
        [Display(Name ="آقا")]
        Mel=1,
        [Display(Name = "خانم")]
        Femael = 2,
        [Display(Name = "سایر")]
        Other =3
    }
}
