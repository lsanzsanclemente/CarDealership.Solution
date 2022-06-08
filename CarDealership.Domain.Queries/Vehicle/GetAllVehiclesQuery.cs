using CarDealership.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CarDealership.Domain.Queries.Vehicle
{
    public class GetAllVehiclesQuery : IRequest<IEnumerable<VehicleDto>>
    {
       
    }
}
