using WebApplication1.Data;

namespace WebApplication1.Repositories;

public class WarehouseRepository : BaseRepository<Warehouse>
{
    private readonly TestContext _context;

    public WarehouseRepository(TestContext context) : base(context)
    {
        _context = context;
    }
}