using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevoxTestTask.BLL.Exceptions;
using DevoxTestTask.BLL.Interfaces;
using DevoxTestTask.DAL;
using DevoxTestTask.DAL.Entities;
using DevoxTestTaskCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace DevoxTestTask.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DevoxTestTaskDbContext _devoxTestTaskDbContext;
        private readonly IMapper _mapper;

        public ProjectService(DevoxTestTaskDbContext devoxTestTaskDbContext, IMapper mapper)
        {
            _devoxTestTaskDbContext = devoxTestTaskDbContext;
            _mapper = mapper;
        }
        public async Task CreateProject(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);

            _devoxTestTaskDbContext.Projects.Add(project);
            await _devoxTestTaskDbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int projectId) {
            if (await _devoxTestTaskDbContext.Projects
                .FirstOrDefaultAsync((project) => project.Id == projectId) == null) {
                throw new NotFoundException("project");
            }

            var project = await _devoxTestTaskDbContext.Projects
                .FirstOrDefaultAsync((project) => project.Id == projectId);

            _devoxTestTaskDbContext.Projects.Remove(project);
            await _devoxTestTaskDbContext.SaveChangesAsync();
        }

        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            var projects = _devoxTestTaskDbContext.Projects.ToList();
            return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public async Task<ProjectDTO> GetProjectById(int id)
        {
            if (await _devoxTestTaskDbContext.Projects
                .FirstOrDefaultAsync((project) => project.Id == id) == null)
            {
                throw new NotFoundException("project");
            }

            var project = await _devoxTestTaskDbContext.Projects
                .FirstOrDefaultAsync((project) => project.Id == id);

            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task UpdateProject(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);

            if (await _devoxTestTaskDbContext.Projects
                .FirstOrDefaultAsync((project) => project.Id == projectDTO.Id) == null)
            {
                throw new NotFoundException("project");
            }

            var currentProject = await _devoxTestTaskDbContext.Projects
                .FirstOrDefaultAsync((project) => project.Id == projectDTO.Id);

            currentProject.Name = project.Name;
            currentProject.DateEnd = project.DateEnd;
            currentProject.DateStart = project.DateStart;

            await _devoxTestTaskDbContext.SaveChangesAsync();
        }
    }
}
