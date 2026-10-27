using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Models;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var projects = new List<Project>
        {
            new Project
            {
                Id = 1,
                Name = "Portfolio API",
                Description = "A REST API built with ASP.NET Core.",
                Technology = "C# and ASP.NET Core",
                Status = "In Progress",
            },
            new Project
            {
                Id = 2,
                Name = "Full-Stack DevOps Portfolio",
                Description = "A portfolio application with automated builds and deployment",
                Technology = "React, ASP.NET Core, Docker",
                Status = "Planned"
            }
        };

        return Ok(projects);
    }
}