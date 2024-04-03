using WebApplication1.Data;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class WarehouseService : IWarehouseService
{
    private readonly WarehouseRepository _context;

    public WarehouseService(WarehouseRepository context)
    {
        _context = context;
    }
    
    public async Task CreateWarehouseAsync(Warehouse warehouse)
    {
        await _context.AddAsync(warehouse);
    }

    public async Task UpdateWarehouseAsync(Warehouse warehouse)
    {
        await _context.UpdateAsync(warehouse);
    }

    public async Task DeleteWarehouseAsync(int id)
    {
        await _context.RemoveAsync(id);
    }

    public async Task<Warehouse> GetWarehouseAsync(int id)
    {
        return await _context.GetAsync(id);
    }

    public async Task<IEnumerable<Warehouse>> GetAllCategoriesAsync()
    {
        return await _context.GetAllAsync();
    }
}