using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var projects = new[]
        {
            new
            {
                id = 1,
                name = "Portfolio API",
                description = "A REST API built with ASP.NET Core.",
                technology = "C# and ASP.NET Core",
                status = "In Progress",
            },
            new
            {
                id = 2,
                name = "Full-Stack DevOps Portfolio",
                description = "A portfolio application with automated builds and deployment",
                technology = "React, ASP.NET Core, Docker",
                status = "Planned"
            }
        };

        return Ok(projects);
    }
}