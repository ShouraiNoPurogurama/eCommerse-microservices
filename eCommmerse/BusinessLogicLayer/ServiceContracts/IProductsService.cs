using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.ServiceContracts;

public interface IProductsService
{
    /// <summary>
    /// Retrieves the list of products from the products repository
    /// </summary>
    /// <returns>List of <see cref="ProductResponse"/> object</returns>
    Task<List<ProductResponse?>> GetProducts();

    /// <summary>
    /// Retrieves list of products matching with given condition
    /// </summary>
    /// <param name="condition">Expression that represents condition to check</param>
    /// <returns>Matching collection of <see cref="ProductResponse"/></returns>
    Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> condition);

    /// <summary>
    /// Retrieves product matching with given condition
    /// </summary>
    /// <param name="condition">Expression that represents condition to check</param>
    /// <returns>Matching <see cref="ProductResponse"/> or null if not found</returns>
    Task<List<ProductResponse?>> GetProductByCondition(Expression<Func<Product, bool>> condition);

    /// <summary>
    /// Adds a product to database
    /// </summary>
    /// <param name="productAddRequest"></param>
    /// <returns>The added <see cref="ProductResponse"/> object or null if failed</returns>
    Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest);

    /// <summary>
    /// Updates an existing product
    /// </summary>
    /// <param name="productUpdateRequest"></param>
    /// <returns>The updated <see cref="ProductResponse"/> object or null if failed</returns>
    Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest);

    /// <summary>
    /// Delete an existing product by given product id
    /// </summary>
    /// <param name="id">id of the product to be deleted</param>
    /// <returns>True if deleted successfully, false otherwise</returns>
    Task<bool> DeleteProduct(Guid id);
}