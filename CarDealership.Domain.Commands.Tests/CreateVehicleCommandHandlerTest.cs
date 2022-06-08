using CarDealership.Domain.Commands.Vehicle;
using CarDealership.Domain.DataInterfaces.Vehicle;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace CarDealership.Domain.Commands.Tests
{
    public class CreateVehicleCommandHandlerTest
    {
        private readonly CreateVehicleCommandHandler _createVehicleCommandHandler;
        
        private readonly Mock<CreateVehicleCommandHandler> _createVehicleCommandMock;
        
        private readonly Mock<IVehicleRepository> _vechicleRepositoryMock = new Mock<IVehicleRepository>();
        
        public CreateVehicleCommandHandlerTest()
        {
            _createVehicleCommandMock = new Mock<CreateVehicleCommandHandler>(_vechicleRepositoryMock.Object);
            _createVehicleCommandHandler = _createVehicleCommandMock.Object;
        }

        public static IEnumerable<object[]> CreateVehicleCommandData =>
            new List<object[]>
            {
                    new object[]
                    {
                        new CreateVehicleCommand {                            
                            Brand = "Peugeot",
                            Model = "308"
                        }
                    }
            };

        [Theory]
        [MemberData(nameof(CreateVehicleCommandData))]
        public void CreateTest(CreateVehicleCommand request)
        {
            var cancellationToken = new CancellationToken();

            var result = _createVehicleCommandHandler.Handle(request, cancellationToken);

            Assert.IsType<int>(result.Result);
        }
    }
}