using Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

public class BlogContextSeed
{
    private readonly BlogContext _dbContext;

    public BlogContextSeed(BlogContext dbContext)
    {
        _dbContext = dbContext;
    }

    public static async Task SeedBlogsAsync(BlogContext dbContext,
            ILoggerFactory loggerFactory, int? retry = 0)
    {
        int retryForAvailability = retry.Value;
        try
        {
            if (!dbContext.Blogs.Any())
            {
                await dbContext.Blogs.AddRangeAsync(SampleBlogData.Instance.Blogs);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability < 3)
            {
                retryForAvailability++;
                var log = loggerFactory.CreateLogger<BlogContextSeed>();
                log.LogError(ex.Message);
                await SeedBlogsAsync(dbContext, loggerFactory, retryForAvailability);
            }
        }
    }

    public static async Task SeedBlogCategoriesAsync(BlogContext dbContext,
            ILoggerFactory loggerFactory, int? retry = 0)
    {
        int retryForAvailability = retry.Value;
        try
        {
            if (!dbContext.BlogCategories.Any())
            {
                // Seed Blog Category: NotSpecified, Insight, Article, News, FeaturedArticle, FeaturedNews
                await dbContext.BlogCategories.AddRangeAsync(SampleBlogData.Instance.BlogCategories);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {           
            if (retryForAvailability < 3)
            {
                retryForAvailability++;
                var log = loggerFactory.CreateLogger<BlogContextSeed>();
                log.LogError(ex.Message);
                await SeedBlogCategoriesAsync(dbContext, loggerFactory, retryForAvailability);
            }
        }
    }

}