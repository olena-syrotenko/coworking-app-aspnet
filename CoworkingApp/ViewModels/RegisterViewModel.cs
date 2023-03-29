using System;
using System.ComponentModel.DataAnnotations;

namespace CoworkingApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Дата народження")]
        public DateTime birthDate { get; set; }

        [Display(Name = "Введіть ім'я")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина ім'я не менше 5 символів")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(20, ErrorMessage = "Довжина пароля 8 символів", MinimumLength = 8)]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Паролі не збігаються")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        public string passwordConfirm { get; set; }
    }
}