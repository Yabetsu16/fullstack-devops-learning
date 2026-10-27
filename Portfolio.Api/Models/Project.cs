using System.ComponentModel.DataAnnotations;

namespace Portfolio.Api.Models;

public class Project
{
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(500, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Technology { get; set; } = string.Empty;
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string Status { get; set; } = string.Empty;
}