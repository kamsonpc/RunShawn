using RunShawn.Core.Helpers;
using RunShawn.Web.Extentions.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace RunShawn.Tests.Helpers
{
    public class ExtentionsTests
    {
        [Fact]
        public void ToSelectList_Transforms_List_To_SelectList()
        {
            //Act
            var expected = new List<SelectListItem>
            {
                 new SelectListItem
                 {
                    Value = 1.ToString(),
                    Text = "Testowy Obiekt 1",
                 },
                new SelectListItem
                {
                    Value = 2.ToString(),
                    Text = "Testowy Obiekt 2",
                },
                new SelectListItem
                {
                    Value = 3.ToString(),
                    Text = "Testowy Obiekt 3",
                }
            };

            //Arrange
            var result = GetExampleList().ToSelectList(x => x.Name, y => y.Id.ToString());

            //Assert
            Assert.Equal(expected[0].Text, result[0].Text);
            Assert.Equal(expected[0].Value, result[0].Value);

            Assert.Equal(expected[2].Text, result[2].Text);
            Assert.Equal(expected[2].Value, result[2].Value);
        }

        [Fact]
        public void Recursive_Strong()
        {
            var result = Helper.Strong(3);
            var result2 = Helper.Strong(5);

            Assert.Equal(6, result);
            Assert.Equal(120, result2);
        }

        private List<TestListItem> GetExampleList()
        {
            return new List<TestListItem>
            {
                new TestListItem
                {
                    Id = 1,
                    Name = "Testowy Obiekt 1",
                    Active = true
                },
                new TestListItem
                {
                    Id = 2,
                    Name = "Testowy Obiekt 2",
                    Active = true
                },
                new TestListItem
                {
                    Id = 3,
                    Name = "Testowy Obiekt 3",
                    Active = false
                }
            };
        }

        private class TestListItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Active { get; set; }
        }
    }
}
