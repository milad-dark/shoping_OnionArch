using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public EditProductCategory GetDetials(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var opration = new OperationResult();
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var peoductCategory = new ProductCategory(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);

            _productCategoryRepository.Create(peoductCategory);
            _productCategoryRepository.SaveChanges();
            return opration.Succedded();
        }

        public OperationResult Edit(EditProductCategory command)
        {
            var opration = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);

            if (productCategory == null)
                return opration.Failed(ApplicationMessages.RecordNotFound);
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return opration.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            productCategory.Edit(command.Name, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            _productCategoryRepository.SaveChanges();

            return opration.Succedded();
        }
    }
}
