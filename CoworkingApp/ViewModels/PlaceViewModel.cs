using CoworkingApp.Data.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoworkingApp.ViewModels
{
    public class PlaceViewModel
    {
        [BindNever]
        public int placeId { get; set; }
        [BindNever]
        public Place place { get; set; }
        [Display(Name = "������ ���� ������� ������")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "����'������ ����")]
        public DateTime rentStart { get; set; }
        [Display(Name = "������ ���� ���� ������")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "����'������ ����")]
        public DateTime rentEnd { get; set; }
    }
}