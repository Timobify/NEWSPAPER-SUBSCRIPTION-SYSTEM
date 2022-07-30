using System.ComponentModel.DataAnnotations;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.NewsPapers
{
    public class NewsPaperSaveModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Fee { get; set; }
    }
}