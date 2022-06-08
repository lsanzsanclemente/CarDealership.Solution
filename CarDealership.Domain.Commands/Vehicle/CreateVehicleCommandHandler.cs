using CarDealership.Domain.DataInterfaces.Vehicle;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealership.Domain.Commands.Vehicle
{
    /// <summary>    
    /// Clase donde se aplica principio solid:    
    /// - Principio de Sustitución de Liskov (uso de clase base de otra derivada)
    /// </summary> 
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, int>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken) 
        {
            return _vehicleRepository.Create(request);
        }
    }
}
