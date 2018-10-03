using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core.Entities;
using Application.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Blog")]
    public class BlogApiController : Controller
    {
        private readonly IPostService _postService;
        private readonly IBlogService _blogService;
        private readonly IBlogRepository _blogRepository;

        public BlogApiController(
            IPostService postService,
            IBlogService blogService,
            IBlogRepository blogRepository)
        {
            _postService = postService;
            _blogService = blogService;
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Blog>> Index()
        {
            return await _blogRepository.GetBlogsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById([FromRoute] int id)
        {
            var blog = await _blogService.GetAllBlogItems(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpGet("Categories")]
        public async Task<IEnumerable<BlogCategory>> GetCategories()
        {
            return await _blogService.GetBlogCategories();
        }

    }
}