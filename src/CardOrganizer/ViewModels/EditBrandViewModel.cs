using System.ComponentModel.DataAnnotations;

namespace CardOrganizer.ViewModels;

public class EditBrandViewModel
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(150, ErrorMessage = "Must be less than 150 characters")]
    public string Name { get; set; } = string.Empty;

    [Range(1, 2, ErrorMessage = "Type is required")]
    [Required(ErrorMessage = "Type is required")]
    public int CardTypeId { get; set; }
    
    public bool IsActive { get; set; }
}