using System.ComponentModel.DataAnnotations;

namespace Roz.WebApp.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}