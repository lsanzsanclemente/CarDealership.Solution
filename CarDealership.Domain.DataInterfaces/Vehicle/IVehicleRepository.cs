using CarDealership.Domain.Entities;
using System.Collections.Generic;

namespace CarDealership.Domain.DataInterfaces.Vehicle
{
    /// <summary>    
    /// Interfaz que aplica principios solid:
    /// - Principio de Segregración de la interfaz (para cada caso concreto)
    /// - Principio de Inversión de dependencias    
    /// </summary>    
    public interface IVehicleRepository
    {
        VehicleDto Get(int id);
        IEnumerable<VehicleDto> GetAll();
        int Create(VehicleDto vehicle);
        bool Update(VehicleDto vehicle);
        bool Delete(int id);        
    }
}
