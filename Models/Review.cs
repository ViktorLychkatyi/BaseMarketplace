using System;
using System.Collections.Generic;

namespace BaseMarketplace.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public string? Сomments { get; set; }

    public int Rating { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
