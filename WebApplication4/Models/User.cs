
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models;

public class User
{
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}