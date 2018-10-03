using Application.Infrastructure.Data;
using IntegrationTests.Builders;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Repositories.BlogRepositoryTests.IntegrationTests
{
    public class GetById
    {
        private readonly BlogContext _blogContext;
        private readonly BlogRepository _blogRepository;

        private readonly ITestOutputHelper _output;

        public GetById(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(databaseName: "TestBlog")
                .Options;
            _blogContext = new BlogContext(dbOptions);
            _blogRepository = new BlogRepository(_blogContext);
        }

        [Fact]
        public void GetsExistingBlog()
        {
            var dummyBlog = BlogBuilder.Instance.DummyBlog();
            _blogContext.Blogs.Add(dummyBlog);
            _blogContext.SaveChanges();
            int blogId = dummyBlog.Id;
            _output.WriteLine($"BlogId: {blogId}");

            var blogFromRepo = _blogRepository.GetById(blogId);
            Assert.Equal(dummyBlog.Id, blogFromRepo.Id);
        }
    }
}
