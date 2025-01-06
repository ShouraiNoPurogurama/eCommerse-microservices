using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var products = await _dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<IEnumerable<Product>> GetProductsByCondition(Expression<Func<Product, bool>> condition)
    {
        return await _dbContext.Products
            .Where(condition)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> condition)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(condition);
    }

    public async Task<Product?> AddProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(product.ProductId));

        if (existingProduct is null)
        {
            return null;
        }

        _dbContext.Products.Update(existingProduct.Adapt(product));
        
        await _dbContext.SaveChangesAsync();
        
        return product;
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(id));

        if (existingProduct is null)
        {
            return false;
        }

        _dbContext.Products.Remove(existingProduct);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}