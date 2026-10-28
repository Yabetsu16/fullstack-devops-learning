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

    [HttpGet("{id:int}")]
    public ActionResult<Project> GetById(int id)
    {
        var project = Projects.FirstOrDefault(p => p.Id == id);

        if (project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Project> Update(int id, Project updatedProject)
    {
        var existingProject = Projects.FirstOrDefault(p => p.Id == id);

        if (existingProject is null)
        {
            return NotFound();
        }

        existingProject.Name = updatedProject.Name;
        existingProject.Description = updatedProject.Description;
        existingProject.Technology = updatedProject.Technology;
        existingProject.Status = updatedProject.Status;

        return Ok(existingProject);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var existingProject = Projects.FirstOrDefault(p => p.Id == id);

        if (existingProject is null)
            return NotFound();

        Projects.Remove(existingProject);

        return NoContent();
    }

    [HttpPost]
    public ActionResult<Project> Create(Project project)
    {
        project.Id = _nextId++;

        Projects.Add(project);

        return CreatedAtAction(
            nameof(GetById),
            new { id = project.Id },
            project
        );
    }
}