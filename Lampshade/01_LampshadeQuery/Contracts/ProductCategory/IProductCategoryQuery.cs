namespace _01_LampshadeQuery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProducts(string slug);
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProducts();
    }
}
