using Portfolio.Api.Models;

namespace Portfolio.Api.Services;

public class ProjectService : IProjectService
{
    private readonly List<Project> _projects = [
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

    private int _nextId = 3;

    public IEnumerable<Project> GetAll()
    {
        return _projects;
    }

    public Project? GetById(int id)
    {
        return _projects.FirstOrDefault(p => p.Id == id);
    }

    public Project Create(Project project)
    {
        project.Id = _nextId++;
        _projects.Add(project);

        return project;
    }

    public Project? Update(int id, Project updatedProject)
    {
        var existingProject = GetById(id);

        if (existingProject is null)
            return null;

        existingProject.Name = updatedProject.Name;
        existingProject.Description = updatedProject.Description;
        existingProject.Technology = updatedProject.Technology;
        existingProject.Status = updatedProject.Status;

        return existingProject;
    }

    public bool Delete(int id)
    {
        var existingProject = GetById(id);

        if (existingProject is null)
            return false;

        _projects.Remove(existingProject);

        return true;
    }
}