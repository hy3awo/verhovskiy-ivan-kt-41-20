using VerhovskiyIvanKT_41_20.Database;
using VerhovskiyIvanKT_41_20.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace VerhovskiyIvanKT_41_20.Interfaces.GroupsInterfaces
{
    public interface IGroupService
    {
        public Task<Group[]> GetGroupsAsync(CancellationToken cancellationToken);
        public Task<Group> GetGroupAsync(int id, CancellationToken cancellationToken);
        public Task AddGroupAsync(Group group, CancellationToken cancellationToken);
        public Task UpdateGroupAsync(Group group, CancellationToken cancellationToken);
        public Task DeleteGroupAsync(Group group, CancellationToken cancellationToken);
    }

    public class GroupService : IGroupService
    {
        public readonly GroupsDbContext _dbContext;
        public GroupService(GroupsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Group[]> GetGroupsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Groups.ToArrayAsync();
        }

        public async Task<Group> GetGroupAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Groups.FindAsync(id);
        }

        
    
    public async Task AddGroupAsync(Group group, CancellationToken cancellationToken = default)
        {

            _dbContext.Groups.Add(group);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(Group group, CancellationToken cancellationToken = default)
        {
       

            _dbContext.Groups.Update(group);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteGroupAsync(Group group, CancellationToken cancellationToken = default)
        {
          

            _dbContext.Groups.Remove(group);
        
            await _dbContext.SaveChangesAsync();
        }

    }
}
