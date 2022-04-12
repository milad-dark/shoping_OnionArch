using System.Collections.Generic;
using _0_Framework.Application;

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
