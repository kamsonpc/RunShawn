using Moq;
using RunShawn.Core.Features.Users;
using RunShawn.Web.Areas.Admin.Controllers;
using System.Web.Mvc;
using Xunit;
using Assert = Xunit.Assert;

namespace RunShawn.Tests.Features.Users
{
    public class UsersControllerTests : ControllerTestBase
    {
        [Fact]
        public void Index_should_redirect_to_list()
        {
            //Arrange
            var mockRepo = new Mock<IUsersService>();
            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = (RedirectToRouteResult)controller.Index();

            //Assert
            Assert.False(result.Permanent);
            Assert.Equal("List", result.RouteValues["Action"]);
            Assert.Equal("Users", result.RouteValues["Controller"]);
        }
    }

}
