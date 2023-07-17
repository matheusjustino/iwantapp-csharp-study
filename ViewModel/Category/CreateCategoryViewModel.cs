namespace IWantApp.ViewModel;

using System.ComponentModel.DataAnnotations;

public class CreateCategoryViewModel
{
    [Required]
    public string Name { get; set; }
}
