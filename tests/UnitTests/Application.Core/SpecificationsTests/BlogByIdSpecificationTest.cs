using Application.Core.Entities;
using Application.Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTests.Application.Core.SpecificationsTests
{
    public class BlogByIdSpecificationTest
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(6, 0)]
        public void MatchesExpectedNumberOfItems(int blogId, int expectedCount)
        {
            var spec = new BlogByIdSpecification(blogId);

            var result = GetTestItemCollection()
                .AsQueryable()
                .Where(spec.Criteria);

            Assert.Equal(expectedCount, result.Count());
        }

        public List<Blog> GetTestItemCollection()
        {
            return new List<Blog>()
            {
                new Blog() { Id = 1, Name = "News", IsPublished = true },
                new Blog() { Id = 2, Name = "Articles", IsPublished = false },
                new Blog() { Id = 3, Name = "Insights", IsPublished = true },
                new Blog() { Id = 4, Name = "Best Artciles", IsPublished = true },
                new Blog() { Id = 5, Name = "Featured Articles", IsPublished = true },
            };
        }
    }
}
