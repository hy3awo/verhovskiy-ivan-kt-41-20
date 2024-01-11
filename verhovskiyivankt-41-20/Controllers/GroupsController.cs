using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VerhovskiyIvanKT_41_20.Database;
using VerhovskiyIvanKT_41_20.Models;
using VerhovskiyIvanKT_41_20.Interfaces.GroupsInterfaces;

namespace VerhovskiyIvanKT_41_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : Controller
    {
        private readonly ILogger<GroupsController> logger;
        private readonly IGroupService _groupService;
        private GroupsDbContext _context;

        public GroupsController(ILogger<GroupsController> logger, IGroupService groupService, GroupsDbContext context)
        {
            this.logger = logger;
            _groupService = groupService;
            _context = context;

        }

        [HttpGet("Get groups")]
        public async Task<IActionResult> GetGroupsAsync(CancellationToken cancellationToken = default)
        {
            var groups = await _groupService.GetGroupsAsync(cancellationToken);
            return Ok(groups);
        }

        [HttpGet("Get groups with id")]
        public async Task<ActionResult<Group>> GetGroupAsync(int id, CancellationToken cancellationToken = default)
        {
            var group = await _groupService.GetGroupAsync(id, cancellationToken);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        [HttpPost("Add groups")]
        [ActionName(nameof(AddGroupAsync))]
        public async Task<IActionResult> AddGroupAsync(Group group, CancellationToken cancellationToken = default)
        {
            await _groupService.AddGroupAsync(group, cancellationToken);
            //return Ok(group);
            return CreatedAtAction(nameof(AddGroupAsync), new { id = group.GroupId }, group);
        }
        //[HttpPost("Add Groups")]
        // public IActionResult CreateGroup([FromBody] Group group)
        // {
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //   }

        //   _context.Groups.Add(group);
        //  _context.SaveChanges();
        //  return Ok(group);
        //}

        [HttpPut("Update group with id")]
        public async Task<IActionResult> UpdateGroupAsync(int id, Group group, CancellationToken cancellationToken = default)
        {
            if (id != group.GroupId)
            {
                return BadRequest();
            }
            await _groupService.UpdateGroupAsync(group, cancellationToken);
            return NoContent();
        }

        [HttpDelete("Delete group with id")]
        public async Task<IActionResult> DeleteGroupAsync(int id, CancellationToken cancellationToken = default)
        {
            var group = await _groupService.GetGroupAsync(id, cancellationToken);
            if (group == null)
            {
                return NotFound();
            }
            await _groupService.DeleteGroupAsync(group, cancellationToken);
            return Ok(group);
        }
        
    }

}
