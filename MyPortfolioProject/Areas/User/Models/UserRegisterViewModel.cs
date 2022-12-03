using System.ComponentModel.DataAnnotations;

namespace MyPortfolioProject.Areas.User.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Adınızı Giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyadınızı Giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Resminizi Yükleyiniz.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage ="Kullanıcı Adını Giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifrenizi Giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrenizi Tekrar Giriniz.")]
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mail Adresinizi Giriniz.")]
        public string Mail { get; set; }
    }
}
