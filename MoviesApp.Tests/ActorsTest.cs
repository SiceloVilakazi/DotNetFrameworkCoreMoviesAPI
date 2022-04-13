using Microsoft.AspNetCore.Mvc;
using Movies.BusinessEntities;
using Movies.BusinessLogic;
using MoviesApp.Controllers;
using System.Collections.Generic;
using Xunit;

namespace MoviesApp.Tests
{
    public class ActorsTest
    {
        private readonly ActorsController _actorsController;
        private readonly ActorService _ActorService;

        public ActorsTest(ActorsController actorsController,ActorService actorService)
        {
            _actorsController = actorsController;
            _ActorService = actorService;
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = (IActionResult)_actorsController.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            IActionResult result = (IActionResult)_actorsController.Get();
            var okResult = result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Actor>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = (IActionResult)_actorsController.Get(100000);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Act
            var okResult = (IActionResult)_actorsController.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Act
            var okResult = (IActionResult)_actorsController.Get(1) as OkObjectResult;

            // Assert
            Assert.IsType<Actor>(okResult.Value);
            Assert.Equal(1, (okResult.Value as Actor).Id);
        }

    }
}
