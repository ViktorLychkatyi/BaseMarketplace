using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseMarketplace.Models;

public partial class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Имя обязательно для заполнения")]
    [StringLength(50, ErrorMessage = "Имя не может превышать 50 символов")]
    public string Name { get; set; } = null!;


    [Required(ErrorMessage = "Цена обязательно для заполнения")]
    [Range(0, 1000000, ErrorMessage = "Цена должна быть в диапазоне от 0 до 1000000")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
