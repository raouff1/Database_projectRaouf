using System.ComponentModel.DataAnnotations;

namespace Data_Bas123.Entities;

public class ProductCategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}