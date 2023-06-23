
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Services;


public class productServices
{

    private readonly SalesDBContext _context;

    public productServices()
    {

    }
    public productServices(SalesDBContext context)
    {
        _context = context;

    }
    public async Task<IEnumerable<Product>> getAllProducts() => await _context.Products.AsNoTracking().ToListAsync();

    public async Task<Product?> getProduct (int id)=>  await _context.Products.FindAsync(id);



    public async Task postProduct (Product products)   {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
    }



    public  async void putProduct (int id, Product? products){

        var idProduct =  await _context.Products.FindAsync(id);

                idProduct!.Category = products!.Category;
                idProduct.Price = products.Price;
                idProduct.Product1 = products.Product1;

               await _context.SaveChangesAsync();
    }


    public async Task deleteProducts(Product products)
    {

        _context.Products.Remove(products);
        await   _context.SaveChangesAsync();


    }
    

    public async Task<Product?> getById (int id) => await _context.Products.SingleOrDefaultAsync( p => p.Id == id);



}