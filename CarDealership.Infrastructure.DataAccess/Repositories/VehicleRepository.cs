using AutoMapper;
using CarDealership.Domain.DataInterfaces.Vehicle;
using CarDealership.Domain.Entities;
using CarDealership.Infrastructure.DataAccess.Entities;
using CarDealership.Infrastructure.DataAccess.Utils.Files;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace CarDealership.Infrastructure.DataAccess.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        public const string URL_REPOSITORY = @"..\Vehicles.json";

        private readonly IMapper _mapper;
       
        public VehicleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public int Create(VehicleDto vehicleDto)
        {
            var vehicles = GetAllDb().ToList();
            
            var newVehicle = new Vehicle
            {
                Id = vehicles.Any() ? vehicles.Max(x => x.Id) + 1 : 1,
                Brand = vehicleDto.Brand,
                Description = vehicleDto.Description,
                Model = vehicleDto.Model,
                Price = vehicleDto.Price,
                Registration = vehicleDto.Registration,
                Year = vehicleDto.Year
            };

            vehicles.Add(newVehicle);

            Operations.SaveTextFile(vehicles, URL_REPOSITORY);

            return newVehicle.Id;
        }

        public bool Delete(int id)
        {
            var vehicles = GetAll().ToList();

            if (vehicles.Any())
            {
                var vehicle = vehicles.FirstOrDefault(x => x.Id == id);

                if (vehicle is not null)
                {
                    vehicles.Remove(vehicle);

                    Operations.SaveTextFile(vehicles, URL_REPOSITORY);

                    return true;
                }
            }

            return false;
        }

        public IEnumerable<VehicleDto> GetAll()
        {
            var vehicles = GetAllDb();

            return _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleDto>>(vehicles);
        }

        public VehicleDto Get(int id)
        {
            var vehicles = GetAll();

            if (vehicles.Any())
            {
                var vehicle = vehicles.FirstOrDefault(x => x.Id == id);

                if (vehicle is not null)
                {
                    return vehicle;
                }
            }

            return new VehicleDto();
        }

        public bool Update(VehicleDto vehicleDto)
        {
            var vehicles = GetAll();

            if (vehicles.Any())
            {
                var vehicle = vehicles.FirstOrDefault(x => x.Id == vehicleDto.Id);

                if (vehicle is not null)
                {
                    vehicle.Brand = vehicleDto.Brand;
                    vehicle.Description = vehicleDto.Description;
                    vehicle.Model = vehicleDto.Model;
                    vehicle.Price = vehicleDto.Price;
                    vehicle.Registration = vehicleDto.Registration;
                    vehicle.Year = vehicleDto.Year;

                    Operations.SaveTextFile(vehicles, URL_REPOSITORY);

                    return true;
                }
            }

            return false;
        }

        private IEnumerable<Vehicle> GetAllDb()
        {
            var fileContent = Operations.GetTextFile(URL_REPOSITORY);

            return JsonSerializer.Deserialize<List<Vehicle>>(fileContent);
        }
    }
}
