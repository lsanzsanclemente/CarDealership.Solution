using CarDealership.Domain.Entities;
using MediatR;

namespace CarDealership.Domain.Commands.Vehicle
{
    public class UpdateVehicleCommand : VehicleDto, IRequest<bool>
    {

    }
}
