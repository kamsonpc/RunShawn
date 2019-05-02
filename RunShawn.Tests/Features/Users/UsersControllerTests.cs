using AutoMapper;
using Moq;
using RunShawn.Core.Features.Roles.Repository;
using RunShawn.Core.Features.Users;
using RunShawn.Core.Features.Users.Model;
using RunShawn.Web.Areas.Admin.Controllers;
using RunShawn.Web.Areas.Admin.Models.Users;
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
            var mockRolesRepo = new Mock<IRolesRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new UsersController(mockRepo.Object, mockRolesRepo.Object, mockMapper.Object);

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

            var mockRolesRepo = new Mock<IRolesRepository>();

            mockRepo.Setup(repo => repo.GetAll()).Returns(GetTestUsers());

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<List<UserListViewModel>>(It.IsAny<List<User>>())).Returns(GetTestsUserList);

            var controller = new UsersController(mockRepo.Object, mockRolesRepo.Object, mockMapper.Object);

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

        private List<UserListViewModel> GetTestsUserList()
        {
            return new List<UserListViewModel>
            {
                new UserListViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "User",
                    LastName = "Testowy"
                },

                 new UserListViewModel
                 {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "User",
                    LastName = "Testowy2"
                 }
            };
        }
    }
}