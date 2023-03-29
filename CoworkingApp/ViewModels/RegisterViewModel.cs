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
        [Display(Name = "���� ����������")]
        public DateTime birthDate { get; set; }

        [Display(Name = "������ ��'�")]
        [StringLength(25)]
        [Required(ErrorMessage = "������� ��'� �� ����� 5 �������")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        [StringLength(20, ErrorMessage = "������� ������ 8 �������", MinimumLength = 8)]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "����� �� ���������")]
        [DataType(DataType.Password)]
        [Display(Name = "ϳ�������� ������")]
        public string passwordConfirm { get; set; }
    }
}