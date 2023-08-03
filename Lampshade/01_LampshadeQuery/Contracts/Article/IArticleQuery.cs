namespace _01_LampshadeQuery.Contracts.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryModel> GetLatestArticles();
        ArticleQueryModel GetArticleDetails(string slug);
    }
}
