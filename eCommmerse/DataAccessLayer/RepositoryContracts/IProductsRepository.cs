using System.Linq.Expressions;

namespace DataAccessLayer.Entities.RepositoryContracts;

public interface IProductsRepository
{
    /// <summary>
    /// Retrieve all products asynchronously
    /// </summary>
    /// <returns>A collection of products</returns>
    Task<IEnumerable<Product>> GetProducts();

    /// <summary>
    /// Retrieves all products based on the specified condition asynchronously
    /// </summary>
    /// <param name="condition"></param>
    /// <returns>A collection of matching products</returns>
    Task<IEnumerable<Product>> GetProductsByCondition(Expression<Func<Product, bool>> condition);

    /// <summary>
    /// Retrieves a single product based on the specified condition asynchronously
    /// </summary>
    /// <param name="condition"></param>
    /// <returns>A single product if matches or null</returns>
    Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> condition);

    /// <summary>
    /// Adds a new product into the database asynchronously
    /// </summary>
    /// <param name="product"> The product to be added</param>
    /// <returns>The added product object or null if unsuccessful</returns>
    Task<Product?> AddProduct(Product product);

    /// <summary>
    /// Updates the existing product
    /// </summary>
    /// <param name="product">The product to be updated</param>
    /// <returns>The updated product, or null if not found</returns>
    Task<Product?> UpdateProduct(Product product);

    /// <summary>
    /// Deletes the product asynchronously
    /// </summary>
    /// <param name="id">The product id to be updated</param>
    /// <returns>True if the deletion is successful, false otherwise</returns>
    Task<bool> DeleteProduct(Guid id);
}