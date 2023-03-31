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
        [Display(Name = "¬вед≥ть дату початку оренди")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "ќбов'€зкове поле")]
        public DateTime rentStart { get; set; }
        [Display(Name = "¬вед≥ть дату к≥нц€ оренди")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "ќбов'€зкове поле")]
        public DateTime rentEnd { get; set; }
    }
}