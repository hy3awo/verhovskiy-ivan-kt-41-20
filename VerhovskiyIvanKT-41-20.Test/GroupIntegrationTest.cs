using VerhovskiyIvanKT_41_20.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerhovskiyIvanKT_41_20;
using VerhovskiyIvanKT_41_20.Models;
using VerhovskiyIvanKT_41_20.Interfaces.GroupsInterfaces;
using System.Diagnostics;

namespace VerhovskiyIvanKT_41_20.Tests
{
    public class GroupIntegrationTest
    {
        public readonly DbContextOptions<GroupsDbContext> _dbContextOptions;

        public GroupIntegrationTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<GroupsDbContext>()
                .UseInMemoryDatabase(databaseName: "test_db")
                .Options;
        }
        [Fact]
        public async Task AddGroupAsync()
        {
            // Arrange
            var ctx = new GroupsDbContext(_dbContextOptions);
            var groupService = new GroupService(ctx);

            var student = new Student
            {
                FirstName = "Верховский",
                LastName = "Васильевич",
                MiddleName = "Иван",
            };
            await ctx.Set<Student>().AddAsync(student);
            await ctx.SaveChangesAsync();

            var group = new Group
            {
                GroupName="КТ-41-20"
            };

            // Act
            await groupService.AddGroupAsync(group);

            // Assert
            var addedGroup = await ctx.Set<Group>().SingleOrDefaultAsync(s => s.GroupName == "КТ-41-20");
            Assert.NotNull(addedGroup);
            Assert.Equal("КТ-41-20", addedGroup.GroupName);
        }
        [Fact]
        public async Task UpdateGroupAsync()
        {
            // Arrange
            var ctx = new GroupsDbContext(_dbContextOptions);
            var groupService = new GroupService(ctx);

            var student = new Student
            {
                FirstName = "Верховский",
                LastName = "Васильевич",
                MiddleName = "Иван",
            };
            await ctx.Set<Student>().AddAsync(student);
            await ctx.SaveChangesAsync();

            var group = new Group
            {
                GroupName="КТ-42-20"
            };
            await ctx.Set<Group>().AddAsync(group);
            await ctx.SaveChangesAsync();

            // Act
            group.GroupName = "КТ-31-20";
            await groupService.UpdateGroupAsync(group, CancellationToken.None);

            // Assert
            Assert.Equal("КТ-31-20", group.GroupName);
        }
    }
}
