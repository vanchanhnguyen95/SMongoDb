using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.Product;

//public class CreateProductDto : CreateOrUpdateProductDto
//{
//    [Required]
//    public string No { get; set; }
//}

public class CreateProductDto
{
    [Required]
    public string No { get; set; }

    public string Name { get; set; }

    public string Summary { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}