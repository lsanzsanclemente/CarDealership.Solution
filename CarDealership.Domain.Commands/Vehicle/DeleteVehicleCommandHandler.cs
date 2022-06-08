using CarDealership.Domain.DataInterfaces.Vehicle;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealership.Domain.Commands.Vehicle
{
    public class DeleteVehicleCommandVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DeleteVehicleCommandVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<bool> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            return _vehicleRepository.Delete(request.Id);
        }
    }
}
