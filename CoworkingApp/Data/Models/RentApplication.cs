using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoworkingApp.Data.Models
{
    public class RentApplication
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введіть ім'я")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина ім'я не менше 5 символів")]
        public string firstName { get; set; }
        [Display(Name = "Введіть прізвище")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина прізвища не менше 5 символів")]
        public string lastName { get; set; }
        [Display(Name = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Довжина номера не менше 10 символів")]
        public string phone { get; set; }
        [Display(Name = "Введіть пошту")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Довжина email не менше 15 символів")]
        public string email { get; set; }
        [BindNever]
        public double totalPrice { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime createTime { get; set; }
        [BindNever]
        public List<RentApplicationDetail> rentDetails { get; set; }
        [BindNever]
        public string userId { get; set; }
        [BindNever]
        public User user { get; set; }
    }
}