using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeProjectApi.Models;
using System;

namespace HomeProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly HomeProjectContext _context;

        public ProjectController(HomeProjectContext context)
        {
            _context = context;
        }

        // GET: api/Project
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            //TODO: Get total and estimated costs based on ProjectItems associated with the project
            var projectItems = _context.ProjectItems.Where(projectItem => projectItem.ProjectId == id).ToList();
            project.ActualTotalCost = projectItems.Sum(item => item.ActualCost);
            project.EstimatedTotalCost = projectItems.Sum(item => item.EstimatedCost);
            project.ActualDuration = projectItems.Max(item => item.ActualDuration);
            project.EstimatedDuration = projectItems.Max(item => item.EstimatedDuration);
            project.ActualEndDate = projectItems.Max(item => item.ActualEndDate);
            project.EstimatedEndDate = projectItems.Max(item => item.EstimatedEndDate);

            return project;
        }
        // POST: api/Project
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }
        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(Guid id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}