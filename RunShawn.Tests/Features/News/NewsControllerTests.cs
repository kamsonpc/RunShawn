using Moq;
using RunShawn.Core.Features.News.News;
using RunShawn.Core.Features.News.News.Model;
using RunShawn.Tests.Helpers;
using RunShawn.Web.Areas.Admin.Controllers;
using RunShawn.Web.Areas.Admin.Models.News;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;
using Assert = Xunit.Assert;

namespace RunShawn.Tests.Features.News
{
    public class NewsControllerTests : TestsBase
    {
        [Fact]
        public void Index_Redirect_To_List()
        {
            //Arrange
            var mockRepo = new Mock<IArticlesService>();
            mockRepo.Setup(repo => repo.GetAll(true)).Returns(GetTestArticles());
            var controller = new NewsController(mockRepo.Object);

            //Act
            var result = controller.List() as ViewResult;

            //Asert
            Assert.Equal(MVC.Admin.News.Views.List, result.ViewName);
        }

        [Fact]
        public void List_View_Result_IsNot_Null()
        {
            //Arrange
            var mockRepo = new Mock<IArticlesService>();
            mockRepo.Setup(repo => repo.GetAll(true)).Returns(GetTestArticles());
            var controller = new NewsController(mockRepo.Object);

            //Act
            var result = controller.List() as ViewResult;

            //Asert
            Assert.NotNull(result.ViewData);
        }

        [Fact]
        public void List_View_Result_CountIsOne()
        {
            //Arrange
            var mockRepo = new Mock<IArticlesService>();
            mockRepo.Setup(repo => repo.GetAll(false)).Returns(GetTestArticles());
            var controller = new NewsController(mockRepo.Object);

            //Act
            var result = controller.List() as ViewResult;

            //Asert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.Single((List<ArticleListViewModel>)result.Model);
        }

        private List<ArticleListView> GetTestArticles()
        {
            return new List<ArticleListView>
            {
                new ArticleListView()
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    Title = "Testowy Artykuł",
                    PublishDate = DateTime.Now,
                    CategoryTitle = "abc",
                    Featured = true,
                    CreatedByName = "admin"
                }
            };
        }
    }
}
