﻿using Contracts.Common.Interfaces;
using Contracts.Domains.Interfaces;
using Infrastructure.Common;
using Product.API.Entities;
using Product.API.Persistence;

namespace Product.API.Repositories.Interfaces;

public interface IProductRepository : IRepositoryBaseAsync<CatalogProduct, long, ProductContext>
{
    Task<IEnumerable<CatalogProduct>> GetProductsAsync();
    Task<CatalogProduct> GetProductAsync(long id);
    Task<CatalogProduct> GetProductByNoAsync(string productNo);
    Task CreateProductAsync(CatalogProduct product);
    Task UpdateProductAsync(CatalogProduct product);
    Task DeleteProductAsync(long id);
}