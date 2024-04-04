using FURNITURE_WEB.CartServices;
using FURNITURE_WEB.Data;
using FURNITURE_WEB.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductsController : Controller
{
    private readonly FurnitureDbContext DbContext;
    private readonly ICartService _cartService;

    public ProductsController(FurnitureDbContext dbContext,ICartService cartService)
    {
        this.DbContext = dbContext;
        this._cartService = cartService;
    }

    /* [HttpPost]

     public async Task<IActionResult> StudyAdmin(ProductsDataView viewModel)
     {
         {
             var furdata = new FURNITURE_WEBDataModel
             {
                 Name = viewModel.Name,
                 Price = viewModel.Price,
                 ImagePath = viewModel.ImagePath,

             };
             await DbContext.FURNITURE_WEBData.AddAsync(furdata);
             await DbContext.SaveChangesAsync();
         }

         return View();
     }*/


    [HttpGet]
    public async Task<IActionResult> StudyTable()
    {
        var studyProducts = await DbContext.ProductsData.ToListAsync();
        return View(studyProducts);
    }
    [HttpGet]
    public async Task<IActionResult> SofaPage()
    {
        var studyProducts1 = await DbContext.SofaData.ToListAsync();
        return View(studyProducts1);
    }
    [HttpGet]
    public async Task<IActionResult> ChairPage()
    {
        var studyProducts2 = await DbContext.Chairtbl.ToListAsync();
        return View(studyProducts2);
    }
    public async Task<IActionResult> ProductDetail(int id)
    {
        var product = await DbContext.Chairtbl.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
    
    public async Task<IActionResult> SofaDetail(int id)
    {
        var product1 = await DbContext.SofaData.FirstOrDefaultAsync(p => p.Id == id);

        if (product1 == null)
        {
            return NotFound();
        }

        return View(product1);
    }
    public async Task<IActionResult> StTableDetail(int id)
    {
        var product1 = await DbContext.ProductsData.FirstOrDefaultAsync(p => p.Id == id);

        if (product1 == null)
        {
            return NotFound();
        }

        return View(product1);
    }
    // ProductsController.cs

    [HttpGet]
     public async Task<IActionResult> CartPage()
    {
        var cartpage = await DbContext.CartData.ToListAsync();
        return View(cartpage);
    }
    [HttpPost]
    public async Task<IActionResult> CartPage1(int id)
    {
        var product = await DbContext.Chairtbl.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        var furdata = new AddCart()
        {

            ProductName = product.Name,
            ProductPrice = product.Price,
            Images = product.ImagePath,
        };

        await DbContext.CartData.AddAsync(furdata);
        await DbContext.SaveChangesAsync();

        return RedirectToAction("CartPage");
    }
    [HttpPost]
    public async Task<IActionResult> CartPage2(int id)
    {
        var product = await DbContext.SofaData.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        var furdata = new AddCart()
        {

            ProductName = product.Name,
            ProductPrice = product.Price,
            Images = product.ImagePath,
        };

        await DbContext.CartData.AddAsync(furdata);
        await DbContext.SaveChangesAsync();

        return RedirectToAction("CartPage");
    }

    [HttpPost]
    public async Task<IActionResult> CartPage3(int id)
    {
        var product = await DbContext.ProductsData.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        var furdata = new AddCart()
        {

            ProductName = product.Name,
            ProductPrice = product.Price,
            Images = product.ImagePath,
        };

        await DbContext.CartData.AddAsync(furdata);
        await DbContext.SaveChangesAsync();

        return RedirectToAction("CartPage");
    }

    [HttpPost]
    public async Task<IActionResult> CartPage(int productId)
    {
        var cartItemToRemove = await DbContext.CartData.FirstOrDefaultAsync(item => item.ProductId == productId);

        if (cartItemToRemove != null)
        {
            DbContext.CartData.Remove(cartItemToRemove);
            await DbContext.SaveChangesAsync();
        }

        return RedirectToAction("CartPage");
    }

}



