using Moq;
using RunShawn.Core.Features.Roles.Model;
using RunShawn.Core.Features.Roles.Repository;
using RunShawn.Core.Features.Roles.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace RunShawn.Tests.Features.Users.Roles
{
    public class RolesTests
    {
        [Fact]
        public void GeneratePermissionsReturnsPermissionsNotNull()
        {
            var mockRolesRepo = new Mock<IRolesRepository>();
            var mockPermRepo = new Mock<IPermissionsRepository>();
            var service = new RolesService(mockPermRepo.Object, mockRolesRepo.Object);

            var expected = GeneratePermissionsList();

            var permissions = GeneratePermissionDictionary();

            var result = service.GeneratePermissions(permissions);
            Assert.Equal(expected[0].Title, result[0].Title);
            Assert.Equal(expected[0].Value, result[0].Value);
            Assert.NotEqual(Guid.Empty.ToString(), result[0].Id);
        }

        [Fact]
        public void IsRebuildPermissionsNeedValidCompare()
        {
            var mockRolesRepo = new Mock<IRolesRepository>();
            var mockPermData = GeneratePermissionsList();
            mockPermData.Add(new Permission { Title = "test", Value = 10 });

            var mockPermRepo = new Mock<IPermissionsRepository>();
            mockPermRepo.Setup(repo => repo.GetAll()).Returns(mockPermData);

            var service = new RolesService(mockPermRepo.Object, mockRolesRepo.Object);

            var permissionsDirectory = GeneratePermissionDictionary();
            var permissions = service.GeneratePermissions(permissionsDirectory);
            var isRebuildIsNeed = service.IsNeedRebuildPermissions(permissions);

            Assert.True(isRebuildIsNeed);
        }

        [Fact]
        public void IsRebuildPermissionsNeed_when_dbtable_empty_returns_true()
        {
            var mockRolesRepo = new Mock<IRolesRepository>();
            var mockPermData = new List<Permission>();

            var mockPermRepo = new Mock<IPermissionsRepository>();
            mockPermRepo.Setup(repo => repo.GetAll()).Returns(mockPermData);

            var service = new RolesService(mockPermRepo.Object, mockRolesRepo.Object);

            var expected = GeneratePermissionsList();

            var permissionsDirectory = GeneratePermissionDictionary();
            var permissions = service.GeneratePermissions(permissionsDirectory);
            var isRebuildIsNeed = service.IsNeedRebuildPermissions(permissions);

            Assert.True(isRebuildIsNeed);
        }

        private List<Permission> GeneratePermissionsList()
        {
            return new List<Permission>
            {
               new Permission
               {
                   Title = "CanEdit",
                   Value = 10
               }
            };
        }

        private Dictionary<int, string> GeneratePermissionDictionary()
        {

            return new Dictionary<int, string>
            {
                { 10, "CanEdit" }
            };

        }
    }
}
