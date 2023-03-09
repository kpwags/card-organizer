using System.ComponentModel.DataAnnotations;

namespace CardOrganizer.ViewModels;

public class AddBaseballCardViewModel
{
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required")]
    [Required(ErrorMessage = "Brand is required")]
    public int BrandId { get; set; }

    [Range(1900, int.MaxValue, ErrorMessage = "Year is required")]
    [Required(ErrorMessage = "Year is required")]
    public int? Year { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Card Number is required")]
    [Required(ErrorMessage = "Card Number is required")]
    public int? CardNumber { get; set; }
    
    [Required(ErrorMessage = "Player Name is required.")]
    [StringLength(255, ErrorMessage = "Must be less than 500 characters")]
    public string PlayerName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Position is required.")]
    [StringLength(50, ErrorMessage = "Must be less than 150 characters")]
    public string Position { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Team is required.")]
    [StringLength(100, ErrorMessage = "Must be less than 150 characters")]
    public string Team { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "Must be less than 150 characters")]
    public string Flags { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Quantity is required")]
    [Required(ErrorMessage = "Quantity is required")]
    public int Quantity { get; set; } = 1;
    
    public string CardImage { get; set; } = string.Empty;
}