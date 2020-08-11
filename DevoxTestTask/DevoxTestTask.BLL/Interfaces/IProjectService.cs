using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevoxTestTaskCommon.Models;

namespace DevoxTestTask.BLL.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDTO> GetAllProjects();

        Task<ProjectDTO> GetProjectById(int id);
        Task CreateProject(ProjectDTO project);
        Task UpdateProject(ProjectDTO project);
        Task DeleteProject(int projectId);
    }
}
