using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        public async Task<IActionResult> Index()
        {
            var warehouses = await _warehouseService.GetAllCategoriesAsync();
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

            await _warehouseService.CreateWarehouseAsync(warehouse);
           
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseAsync(id);
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

            await _warehouseService.UpdateWarehouseAsync(warehouse);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            //var warehouse = await _warehouseService.GetWarehouseAsync(id);

            await _warehouseService.DeleteWarehouseAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
