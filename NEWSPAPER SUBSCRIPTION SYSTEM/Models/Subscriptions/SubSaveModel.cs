using System;
using System.ComponentModel.DataAnnotations;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.Subscriptions
{
    public class SubSaveModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int NewsPaperId { get; set; }
        [Required]
        public DateTime Start_Date { get; set; }
        [Required]
        public DateTime End_Date { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public string Status { get; set; }
    }
}