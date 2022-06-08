using CarDealership.Domain.Commands.Vehicle;
using CarDealership.Domain.Entities;
using CarDealership.Domain.Queries.Vehicle;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealership.Application.Services.Vehicle
{
    /// <summary>
    /// Servicio que aplica principios solid:
    /// - De responsabilidad única
    /// - Abierto/Cerrado
    /// </summary>
    public class VehicleService : IVehicleService
    {
        private readonly IMediator _mediator;

        public VehicleService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<VehicleDto> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetVehicleQuery(id), cancellationToken);            
        }

        public async Task<IEnumerable<VehicleDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetAllVehiclesQuery(), cancellationToken);
        }

        public async Task<int> CreateAsync(CreateVehicleCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        public async Task<bool> UpdateAsync(UpdateVehicleCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command, cancellationToken);           
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteVehicleCommand(id), cancellationToken);
        }
    }
}
