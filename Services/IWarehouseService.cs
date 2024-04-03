using WebApplication1.Data;

namespace WebApplication1.Services;

public interface IWarehouseService
{
    Task CreateWarehouseAsync(Warehouse warehouse);
    Task UpdateWarehouseAsync(Warehouse warehouse);
    Task DeleteWarehouseAsync(int id);
    Task<Warehouse> GetWarehouseAsync(int id);
    Task<IEnumerable<Warehouse>> GetAllCategoriesAsync();
}