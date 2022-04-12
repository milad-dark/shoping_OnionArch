using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OprationResult Create(CreateProductCategory command);
        OprationResult Edit(EditProductCategory command);
        EditProductCategory GetDetials(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
