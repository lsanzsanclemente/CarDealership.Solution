using CarDealership.Application.Services.Vehicle;
using CarDealership.Domain.Entities;
using MediatR;
using Moq;
using System.Threading;
using Xunit;

namespace CarDealership.Application.Tests
{
    public class VehicleServiceTests
    {
        private readonly Mock<IMediator> _mediatorMock = new Mock<IMediator>();

        private readonly VehicleService _vehicleService;

        private readonly Mock<VehicleService> _vehicleServiceMock;

        public VehicleServiceTests()
        {
            _vehicleServiceMock = new Mock<VehicleService>(_mediatorMock.Object);
            _vehicleService = _vehicleServiceMock.Object;
        }

        [Theory]
        [InlineData(1)]
        public void GetAsync(int id)
        {
            var cancellationToken = new CancellationToken();

            _mediatorMock.Setup(x => x.Send(It.IsAny<IRequest<VehicleDto>>(), It.IsAny<CancellationToken>())).ReturnsAsync(new VehicleDto { Id = 1});

            var result = _vehicleService.GetAsync(id, cancellationToken);

            _mediatorMock.Verify(x => x.Send(It.IsAny<IRequest<VehicleDto>>(), It.IsAny<CancellationToken>()), Times.Once);

            Assert.True(result.Result.Id > 0);
        }
    }
}