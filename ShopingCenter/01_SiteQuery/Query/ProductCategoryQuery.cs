using _01_SiteQuery.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_SiteQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context = context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.productCategories.Select(c => new ProductCategoryQueryModel
            {
                Id = c.Id,
                Name = c.Name,
                Picture = c.Picture,
                PictureAlt = c.PictureAlt,
                PictureTitle = c.PictureTitle,
                Slug = c.Slug,
            }).ToList();
        }
    }
}
