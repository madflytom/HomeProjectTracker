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
    public class ProjectItemsController : ControllerBase
    {
        private readonly HomeProjectContext _context;

        public ProjectItemsController(HomeProjectContext context)
        {
            _context = context;
        }

        // GET: api/ProjectItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectItem>>> GetProjectItems()
        {
            return await _context.ProjectItems.ToListAsync();
        }

        // GET: api/ProjectItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectItem>> GetProjectItem(Guid id)
        {
            var projectItems = await _context.ProjectItems.FindAsync(id);

            if (projectItems == null)
            {
                return NotFound();
            }

            return projectItems;
        }
        // POST: api/ProjectItem
        [HttpPost]
        public async Task<ActionResult<ProjectItem>> PostProject(ProjectItem projectItem)
        {
            _context.ProjectItems.Add(projectItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjectItem), new { id = projectItem.Id }, projectItem);
        }
        // PUT: api/ProjectItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectItem(Guid id, ProjectItem projectItem)
        {
            if (id != projectItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/ProjectItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectItem(Guid id)
        {
            var projectItem = await _context.ProjectItems.FindAsync(id);

            if (projectItem == null)
            {
                return NotFound();
            }

            _context.ProjectItems.Remove(projectItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}