using System;
using System.Collections.Generic;

namespace BaseMarketplace.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly Date { get; set; }

    public decimal? Price { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
