using LocationManager.Models;

namespace LocationManager.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<bool> AddLocation(Location location);
        Task<bool> UpdateLocation(Location location);
        Task<bool> DeleteLocation(int id);
    }
}
