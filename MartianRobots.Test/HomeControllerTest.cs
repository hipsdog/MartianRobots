using MartianRobots.Controllers;
using MartianRobots.Domain.DomainEntities;
using MartianRobots.Domain.Interfaces;
using MartianRobots.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MartianRobots.Test
{
    public class HomeControllerTest
    {
        Mock<ILogger<HomeController>> _loggerMock = new();
        Mock<IUnitOfWork> _unitOfWork = new();

        [Fact]
        public void HomeController_Index_Post_Valid()
        {
            //Arrange
            string input = @"5 3
                            1 1 E
                            RFRFRFRF
                            3 2 N
                            FRRFLLFFRRFLL
                            0 3 W
                            LLFFFRFLFL";

            MartianModel martianModel = new();
            martianModel.WorldInput = input;

            _unitOfWork.Setup(x => x.MartianWorlds.Add(It.IsAny<MartianWorldEntity>()))
                .Returns(Task.FromResult(default(object)));

            _unitOfWork.Setup(x => x.Complete()).Returns(It.IsAny<int>());

            var controller = new HomeController(_loggerMock.Object, _unitOfWork.Object);

            //Act
            var result = controller.Index(martianModel);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MartianModel>(viewResult.ViewData.Model);

            Assert.NotNull(model);
            Assert.Equal("1 1 E", model.WorldResult[0].Trim());
            Assert.Equal("3 3 N LOST", model.WorldResult[1].Trim());
            Assert.Equal("4 2 N", model.WorldResult[2].Trim());
        }
    }
}
