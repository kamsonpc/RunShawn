using Moq;
using RunShawn.Core.Features.Users;
using RunShawn.Core.Features.Users.Model;
using RunShawn.Web.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
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

        [Fact]
        public void List_View_Result_IsNot_Null()
        {
            //Arrange
            var mockRepo = new Mock<IUsersService>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestUsers());
            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = controller.List() as ViewResult;

            //Asert
            Assert.NotNull(result.Model);
        }

        private List<User> GetTestUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "User",
                    LastName = "Testowy",
                    Email = "testemail@gmail.com"
                },

                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "User",
                    LastName = "Testowy2",
                    Email = "email2@gmail.com",
                }
            };
        }
    }
}
