using FURNITURE_WEB.Data;
using FURNITURE_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FURNITURE_WEB.Controllers
{
    public class FurnitureDataController : Controller
    {
        private readonly FurnitureDbContext DbContext;

        public FurnitureDataController(FurnitureDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult FurnitureDataView()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> FurnitureDataView(FurnitureViewModel viewModel)
        {
            {
                var furdata = new FurnitureDataModel
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    ImagePath = viewModel.ImagePath,

                };
                await DbContext.FurnitureData.AddAsync(furdata);
                await DbContext.SaveChangesAsync();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await DbContext.FurnitureData.ToListAsync();
            return View(students);
        }
    }
}
