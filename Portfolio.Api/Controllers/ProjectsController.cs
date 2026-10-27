using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.Models;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private static readonly List<Project> Projects = [
        new Project
        {
            Id = 1,
            Name = "Portfolio API",
            Description = "A REST API built with ASP.NET Core.",
            Technology = "C# and ASP.NET Core",
            Status = "In Progress"
        },
        new Project
        {
            Id = 2,
            Name = "Full-Stack DevOps Portfolio",
            Description = "A portfolio application with automated builds and deployment",
            Technology = "React, ASP.NET Core, Docker",
            Status = "Planned"
        }
    ];

    private static int _nextId = 3;

    [HttpGet]
    public ActionResult<IEnumerable<Project>> Get()
    {
        return Ok(Projects);
    }

    [HttpPost]
    public ActionResult<Project> Create(Project project)
    {
        project.Id = _nextId++;

        Projects.Add(project);

        return CreatedAtAction(
            nameof(Get),
            new { id = project.Id },
            project
        );
    }
}