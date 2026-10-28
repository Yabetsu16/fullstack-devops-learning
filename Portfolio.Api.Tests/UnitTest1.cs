
using Portfolio.Api.Models;
using Portfolio.Api.Services;

namespace Portfolio.Api.Tests;

public class ProjectServiceTests
{
    [Fact]
    public void Create_ShouldAssignIdAndStoreProject()
    {
        // Arrange
        var service = new ProjectService();

        var project = new Project
        {
            Name = "Unit Test Project",
            Description = "A project created for unit testing.",
            Technology = "C# and xUnit",
            Status = "In Progress"
        };

        // Act
        var createdProject = service.Create(project);

        // Assert
        Assert.Equal(3, createdProject.Id);
        Assert.Equal("Unit Test Project", createdProject.Name);
        Assert.Contains(createdProject, service.GetAll());
    }


    [Fact]
    public void Update_ShouldModifyExistingProject()
    {
        // Arrange
        var service = new ProjectService();

        var updatedProject = new Project
        {
            Name = "Updated Portfolio API",
            Description = "An updated project for unit testing.",
            Technology = "C#, ASP.NET Core, xUnit",
            Status = "Completed"
        };

        // Act
        var result = service.Update(1, updatedProject);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Updated Portfolio API", result.Name);
        Assert.Equal("Completed", result.Status);
    }


    [Fact]
    public void Delete_ShouldRemoveExistingProject()
    {
        // Arrange
        var service = new ProjectService();

        // Act
        var result = service.Delete(1);

        // Assert
        Assert.True(result);
        Assert.Null(service.GetById(1));
    }

    [Fact]
    public void Delete_ShouldReturnFalseForNonexistentProject()
    {
        // Arrange
        var service = new ProjectService();

        // Act
        var result = service.Delete(999);

        // Assert
        Assert.False(result);
    }


    [Fact]
    public void GetById_ShouldReturnNullForNonexistentProject()
    {
        // Arrange
        var service = new ProjectService();

        // Act
        var result = service.GetById(999);

        // Assert
        Assert.Null(result);
    }


}
