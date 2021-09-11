using System.ComponentModel.DataAnnotations;

namespace WebExample.Models.Enums
{
    public enum SpendStatus : int
    {
        [Display(Name = "Pending")]
        Pending = 0,
        [Display(Name = "Paid")]
        Paid = 1,
        [Display(Name = "Cancelled")]
        Cancelled = 2
    }
}
