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
        [Display(Name = "������ ��'�")]
        [StringLength(25)]
        [Required(ErrorMessage = "������� ��'� �� ����� 5 �������")]
        public string firstName { get; set; }
        [Display(Name = "������ �������")]
        [StringLength(25)]
        [Required(ErrorMessage = "������� ������� �� ����� 5 �������")]
        public string lastName { get; set; }
        [Display(Name = "������ ����� ��������")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "������� ������ �� ����� 10 �������")]
        public string phone { get; set; }
        [Display(Name = "������ �����")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "������� email �� ����� 15 �������")]
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