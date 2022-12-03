using System.ComponentModel.DataAnnotations;

namespace MyPortfolioProject.Areas.User.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adını Giriniz.")]
        public string Username { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifrenizi Giriniz..")]
        public string Password { get; set; }
    }
}
