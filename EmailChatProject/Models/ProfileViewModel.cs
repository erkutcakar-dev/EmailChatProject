using System.ComponentModel.DataAnnotations;

namespace EmailChatProject.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProfileViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Display(Name = "Telefon Numarası")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Display(Name = "Profil Resmi URL")]
        public string ProfileImageUrl { get; set; }
    }


}
