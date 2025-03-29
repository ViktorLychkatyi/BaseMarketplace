using System;
using System.Collections.Generic;

namespace BaseMarketplace.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null;

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
