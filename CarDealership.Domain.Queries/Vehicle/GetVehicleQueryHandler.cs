using CarDealership.Domain.DataInterfaces.Vehicle;
using CarDealership.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealership.Domain.Queries.Vehicle
{    
    public class GetVehicleQueryHandler : IRequestHandler<GetVehicleQuery, VehicleDto>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public GetVehicleQueryHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto> Handle(GetVehicleQuery request, CancellationToken cancellationToken)
        {
            return _vehicleRepository.Get(request.Id);            
        }
    }
    
}
