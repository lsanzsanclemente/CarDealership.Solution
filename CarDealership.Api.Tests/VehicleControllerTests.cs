using CarDealership.Api.Controllers;
using CarDealership.Application.Services.Vehicle;
using CarDealership.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading;
using Xunit;

namespace CarDealership.Api.Tests
{
    public class VehicleControllerTests
    {        
        private readonly VehicleController _vehicleController;
        private readonly Mock<VehicleController> _vehicleControllerMock;
        private readonly Mock<IVehicleService> _vechicleServiceMock = new Mock<IVehicleService>();
        private readonly Mock<ILogger<VehicleController>> _loggerMock = new Mock<ILogger<VehicleController>>();

        public VehicleControllerTests()
        {
            _vehicleControllerMock = new Mock<VehicleController>(_loggerMock.Object, _vechicleServiceMock.Object);
            _vehicleController = _vehicleControllerMock.Object;
        }

        [Theory]
        [InlineData(1)]
        public void GetTest(int id)
        {            
            var cancellationToken = new CancellationToken();

            _vechicleServiceMock.Setup(x => x.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(new VehicleDto { Id = 1 });

            var result = _vehicleController.GetAsync(id, cancellationToken);

            _vechicleServiceMock.Verify(x => x.GetAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);

            Assert.True(result.Result.Id > 0);
        }
    }
}