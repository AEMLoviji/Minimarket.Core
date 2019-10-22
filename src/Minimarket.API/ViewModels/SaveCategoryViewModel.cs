using System.ComponentModel.DataAnnotations;

namespace Minimarket.API.ViewModels
{
    public class SaveCategoryViewModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}