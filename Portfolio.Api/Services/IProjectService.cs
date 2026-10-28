using Portfolio.Api.Models;

namespace Portfolio.Api.Services;

public interface IProjectService
{
    IEnumerable<Project> GetAll();

    Project? GetById(int id);

    Project Create(Project project);

    Project? Update(int id, Project updatedProject);

    bool Delete(int id);
}