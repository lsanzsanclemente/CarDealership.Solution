using MediatR;

namespace CarDealership.Domain.Commands.Vehicle
{
    public class DeleteVehicleCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteVehicleCommand(int id)
        {
            Id = id;
        }
    }
}
