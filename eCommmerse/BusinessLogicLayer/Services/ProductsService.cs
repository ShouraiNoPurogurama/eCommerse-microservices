using System.Linq.Expressions;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.ServiceContracts;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.RepositoryContracts;
using FluentValidation;
using Mapster;

namespace BusinessLogicLayer.Services;

public class ProductsService : IProductsService
{
    private readonly IValidator<ProductAddRequest> _productAddRequestValidator;
    private readonly IValidator<ProductUpdateRequest> _productUpdateRequestValidator;
    private readonly IProductsRepository _productsRepository;

    public ProductsService(IValidator<ProductAddRequest> productAddRequestValidator, IValidator<ProductUpdateRequest> productUpdateRequestValidator, IProductsRepository productsRepository)
    {
        _productAddRequestValidator = productAddRequestValidator;
        _productUpdateRequestValidator = productUpdateRequestValidator;
        _productsRepository = productsRepository;
    }

    public async Task<List<ProductResponse?>> GetProducts()
    {
        var product = await _productsRepository.GetProducts();

        var productResponse = product.Adapt<IEnumerable<ProductResponse?>>();

        return productResponse.ToList();
    }

    public async Task<List<ProductResponse?>> GetProductsByCondition(Expression<Func<Product, bool>> condition)
    {
        var product = await _productsRepository.GetProductsByCondition(condition);

        var productResponse = product.Adapt<IEnumerable<ProductResponse?>>();

        return productResponse.ToList();
    }

    public async Task<List<ProductResponse?>> GetProductByCondition(Expression<Func<Product, bool>> condition)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductResponse?> AddProduct(ProductAddRequest productAddRequest)
    {
        ArgumentNullException.ThrowIfNull(productAddRequest);

        var validationResult = await _productAddRequestValidator.ValidateAsync(productAddRequest);

        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ArgumentException(errorMessages);
        }

        var productInput = productAddRequest.Adapt<Product>();

        var addedProduct = await _productsRepository.AddProduct(productInput);

        return addedProduct.Adapt<ProductResponse>();
    }

    public async Task<ProductResponse?> UpdateProduct(ProductUpdateRequest productUpdateRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteProduct(Guid id)
    {
        var existingProduct = await _productsRepository.GetProductByCondition(p => p.ProductId.Equals(id));

        if (existingProduct is null)
        {
            return false;
        }

        var result = await _productsRepository.DeleteProduct(id);

        return result;
    }
}