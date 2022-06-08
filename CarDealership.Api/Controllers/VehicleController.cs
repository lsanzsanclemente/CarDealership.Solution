using CarDealership.Application.Services.Vehicle;
using CarDealership.Domain.Commands.Vehicle;
using CarDealership.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CarDealership.Api.Controllers
{
    /// <summary>
    /// CarDealership's vehicles management
    /// </summary>
    /// <remarks> CarDealership's vehicles management
    /// </remarks> 
    [ApiController]    
    [Route("[controller]")]    
    public class VehicleController : ControllerBase
    {        
        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _vehicleService;

        /// <summary>
        /// Vehicle's controller constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="vehicleService"></param>
        public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService)
        {
            _logger = logger;            
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Gets Vehicle by Id
        /// </summary>
        /// <remarks> Gets Vehicle from CarDelearship by param Id
        /// </remarks> 
        [HttpGet]
        [Route("{id}")]
        public async Task<VehicleDto> GetAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(VehicleController)} - Gets Vehicle by Id: {id}");

            return await _vehicleService.GetAsync(id, cancellationToken);
        }

        /// <summary>
        /// Gets all vehicles
        /// </summary>
        /// <remarks> Gets all vehicles from CarDelearship
        /// </remarks> 
        [HttpGet]        
        public async Task<IEnumerable<VehicleDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(VehicleController)} - Gets all vehicles");

            return await _vehicleService.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Creates vehicle 
        /// </summary>
        /// <remarks> Adds a new vehicle to the CarDelearship
        /// </remarks> 
        [HttpPost]
        public async Task<int> CreateAsync(CreateVehicleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(VehicleController)} - Creates vehicle: {command.Brand}/{command.Model}");

            return await _vehicleService.CreateAsync(command, cancellationToken);
        }

        /// <summary>
        /// Updates vehicle 
        /// </summary>
        /// <remarks> Edits an existing vehicle in the CarDelearship
        /// </remarks> 
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateVehicleCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(VehicleController)} - Updates vehicle with id: {command.Id}");

            var result = await _vehicleService.UpdateAsync(command, cancellationToken);

            if (!result)
            {
                _logger.LogError($"{nameof(VehicleController)} - Unable to update vehicle with id: {command.Id}");

                return NotFound();
            }

            return Ok();            
        }

        /// <summary>
        /// Deletes vehicle by Id
        /// </summary>
        /// <remarks> Deletes an existing vehicle in the CarDelearship
        /// </remarks> 
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(VehicleController)} - Deletes vehicle with id: {id}");

            var result = await _vehicleService.DeleteAsync(id, cancellationToken);

            if (!result)
            {
                _logger.LogError($"{nameof(VehicleController)} - Unable to delete vehicle with id: {id}");

                return NotFound();
            }

            return Ok();
        }
    }
}
