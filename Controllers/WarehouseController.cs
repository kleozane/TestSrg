using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly TestContext _context;

        public WarehouseController(TestContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var warehouses = await _context.Warehouses.ToListAsync();
            return View(warehouses);
        }

        public async Task<IActionResult> Add()
        {
            var model = new WarehouseForCreation();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(WarehouseForCreation model)
        {
            var warehouse = new Warehouse
            {
                Name = model.Name,
                Description = model.Description
            };
            
            await _context.AddAsync(warehouse);
            await _context.SaveChangesAsync();
           
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            var model = new WarehouseForModification
            {
                Id = id,
                Name = warehouse.Name,
                Description = warehouse.Description
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WarehouseForModification model)
        {
            var warehouse = new Warehouse
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            _context.Update(warehouse);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            
            _context.Remove(warehouse);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
