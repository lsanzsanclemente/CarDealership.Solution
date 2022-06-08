using CarDealership.Domain.DataInterfaces.Vehicle;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealership.Domain.Commands.Vehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<bool> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            return _vehicleRepository.Update(request);
        }
    }
}
