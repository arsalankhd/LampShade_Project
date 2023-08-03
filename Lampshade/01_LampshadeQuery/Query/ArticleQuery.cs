using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Article;
using BlogManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampshadeQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;

        public ArticleQuery(BlogContext context)
        {
            _context = context;
        }
        public List<ArticleQueryModel> GetLatestArticles()
        {
            return _context.Articles
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    Slug = x.Slug,
                }).Take(4).OrderByDescending(x => x.Id).ToList();
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article = _context.Articles
                  .Include(x => x.Category)
                  .Where(x => x.PublishDate <= DateTime.Now)
                  .Select(x => new ArticleQueryModel
                  {
                      Title = x.Title,
                      ShortDescription = x.ShortDescription,
                      Description = x.Description,
                      Picture = x.Picture,
                      PictureAlt = x.PictureAlt,
                      PictureTitle = x.Title,
                      PublishDate = x.PublishDate.ToFarsi(),
                      Slug = x.Slug,
                      Keywords = x.Keywords,
                      MetaDescription = x.MetaDescription,
                      CanonicalAddress = x.CanonicalAddress,
                      CategoryName = x.Category.Name,
                      CategorySlug = x.Category.Slug
                  }).FirstOrDefault(x => x.Slug == slug);

            if (!string.IsNullOrWhiteSpace(article.Keywords))
                article.KeywordList = article.Keywords.Split("،").ToList();

            return article;
        }
    }
}
