using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core.Entities;
using Application.Core.Interfaces;
using Application.Core.Specifications;
using Ardalis.GuardClauses;

namespace Application.Core.Services
{
    public class BlogService: IBlogService
    {
        private readonly IAppLogger<BlogService> _logger;
        private readonly IAsyncRepository<Blog> _blogRepository;
        private readonly IAsyncRepository<BlogCategory> _categoryRepository;

        public BlogService(
            IAppLogger<BlogService> logger,
            IAsyncRepository<Blog> blogRepository,
            IAsyncRepository<BlogCategory> categoryRepository
            )
        {
            _logger = logger;
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddBlogAsync(Blog blog)
        {
            await _blogRepository.AddAsync(blog);
        }

        public async Task DeleteBlogAsync(Blog blog)
        {
            await _blogRepository.DeleteAsync(blog);
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await _blogRepository.ListAllAsync();
        }

        public async Task<IEnumerable<Blog>> GetAllBlogItems(int blogId)
        {
            var spec = new BlogByIdSpecification(blogId);
            return await _blogRepository.ListAsync(spec);
        }

        public async Task<Blog> GetBlogById(int blogId)
        {
            var blog = await _blogRepository.GetByIdAsync(blogId);
            Guard.Against.NullBlog(blogId, blog);
            return blog; 
        }

        public async Task SetBogAsync(Blog blog)
        {
            Guard.Against.Null(blog, nameof(blog));
            Guard.Against.NullBlog(blog.Id, blog);
            await _blogRepository.UpdateAsync(blog);
        }

        public async Task<IEnumerable<BlogCategory>> GetBlogCategories()
        {
            return await _categoryRepository.ListAllAsync();
        }
    }
}
