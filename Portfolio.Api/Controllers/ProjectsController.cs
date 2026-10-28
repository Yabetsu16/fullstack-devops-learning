using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using Portfolio.Api.Models;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Project>> Get()
    {
        return Ok(_projectService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Project> GetById(int id)
    {
        var project = _projectService.GetById(id);

        if (project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public ActionResult<Project> Create(Project project)
    {
        var createdProject = _projectService.Create(project);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdProject.Id },
            createdProject
        );
    }

    [HttpPut("{id:int}")]
    public ActionResult<Project> Update(int id, Project updatedProject)
    {
        var existingProject = _projectService.Update(id, updatedProject);

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
        var deleted = _projectService.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }


}