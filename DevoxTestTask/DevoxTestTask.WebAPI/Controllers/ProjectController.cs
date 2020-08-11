using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxTestTask.BLL.Interfaces;
using DevoxTestTaskCommon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevoxTestTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<ProjectDTO>> GetAllProjects()
        {
            return Ok(_projectService.GetAllProjects());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectById(int id)
        {
            return Ok( await _projectService.GetProjectById(id));
        }

        [HttpPost()]
        public async Task<ActionResult> CreateProject([FromBody]ProjectDTO projectDTO)
        {
            await _projectService.CreateProject(projectDTO);

            return CreatedAtAction("CreateProject", new { Name = projectDTO.Name });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProject(id);

            return NoContent();
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateProject([FromBody] ProjectDTO projectDTO)
        {
            await _projectService.UpdateProject(projectDTO);

            return NoContent();
        }
    }
}