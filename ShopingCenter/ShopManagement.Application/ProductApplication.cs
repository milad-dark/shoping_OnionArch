﻿using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var opration = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId, slug, command.Keywords, command.MetaDescription);
            _productRepository.Create(product);
            _productRepository.SaveChanges();

            return opration.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var opration = new OperationResult();
            var product = _productRepository.Get(command.Id);

            if (product == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId, slug, command.Keywords, command.MetaDescription);

            _productRepository.SaveChanges();
            return opration.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public OperationResult IsStock(long Id)
        {
            var opration = new OperationResult();
            var product = _productRepository.Get(Id);

            if (product == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            product.InStock();

            _productRepository.SaveChanges();
            return opration.Succedded();
        }

        public OperationResult NotIsStock(long Id)
        {
            var opration = new OperationResult();
            var product = _productRepository.Get(Id);

            if (product == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);

            product.NotInStock();

            _productRepository.SaveChanges();
            return opration.Succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}