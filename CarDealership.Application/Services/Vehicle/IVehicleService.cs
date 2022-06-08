using CarDealership.Domain.Commands.Vehicle;
using CarDealership.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealership.Application.Services.Vehicle
{
    /// <summary>    
    /// Interfaz que aplica principio solid:
    /// Principio de Segregración de la interfaz (para cada caso concreto)
    /// </summary>
    public interface IVehicleService
    {
        Task<VehicleDto> GetAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<VehicleDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<int> CreateAsync(CreateVehicleCommand command, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(UpdateVehicleCommand command, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
