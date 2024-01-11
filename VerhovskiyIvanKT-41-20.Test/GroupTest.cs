using System.Text.RegularExpressions;
using VerhovskiyIvanKT_41_20.Models;


namespace VerhovskiyIvanKT_41_20.Tests
{
    public class GroupTest
    {
        [Fact]
        public void GroupNameTest()
        {
            // Arrange
            var testGroup = new Models.Group
            {
                GroupId = 1,
                GroupName = "AB-111-22",
            };
            // Act
            var result = testGroup.IsValidGroupName();
            // Assert
            Assert.True(result);

        }

    }
}