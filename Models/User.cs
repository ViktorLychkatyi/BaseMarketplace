using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseMarketplace.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Имя обязательно для заполнения")]
    [StringLength(50, ErrorMessage = "Имя не может превышать 50 символов")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email обязателен для заполнения")]
    [StringLength(50, ErrorMessage = "Email не может превышать 50 символов")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Пароль обязателен для заполнения")]
    [StringLength(50, ErrorMessage = "Пароль не может превышать 50 символов")]
    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
