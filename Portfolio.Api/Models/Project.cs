namespace Portfolio.Api.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Technology { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}