using LocationManager.Data;
using LocationManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationManager.Services
{
    public class LocationService:ILocationService
    {
        private readonly ApDbContext _dbContext;
        public LocationService(ApDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            try
            {
                var locations = await _dbContext.Locations.ToListAsync();
                return locations;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> AddLocation(Location location)
        {
            try
            {
                _dbContext.Locations.Add(location);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> UpdateLocation(Location location)
        {
            try
            {
                var _location = await _dbContext.Locations.FindAsync(location.Id);

                if (_location != null)
                {
                    _location.Name = location.Name;
                    _location.Address = location.Address;
                    _location.Phone = location.Phone;
                    _location.Latitude = location.Latitude;
                    _location.Longitude = location.Longitude;
                    _location.Company = location.Company;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> DeleteLocation(int id)
        {
            try
            {
                var location = await _dbContext.Locations.FindAsync(id);
                if(location != null)
                {
                    _dbContext.Locations.Remove(location);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
