using LocationManager.Models;
using LocationManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var locations =await _locationService.GetAllLocations();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddLocation(Location location)
        {
            try
            {
               var res= await _locationService.AddLocation(location);
                if (res)
                {
                    return Ok("Successfully added new location");
                }
                return BadRequest("Please fill all fields");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpadteLocation(Location location)
        {
            try
            {
                var res = await _locationService.UpdateLocation(location);
                if (res)
                {
                    return Ok("Successfully updated location");
                }
                return NotFound("Location not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                var res = await _locationService.DeleteLocation(id);
                if (res)
                {
                    return Ok("Successfully deleted location");
                }
                return NotFound("Location not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
