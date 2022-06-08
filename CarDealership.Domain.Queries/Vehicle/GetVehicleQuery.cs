using CarDealership.Domain.Entities;
using MediatR;

namespace CarDealership.Domain.Queries.Vehicle
{
    public class GetVehicleQuery : IRequest<VehicleDto>
    {
        public int Id { get; set; }

        public GetVehicleQuery(int id)
        {
            Id = id;
        }
    }
}
