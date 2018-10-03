using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core.Entities;
using Application.Core.Enums;
using Application.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IPostRepository _postRepository;

        public PostController(IPostService postService, IPostRepository postRepository)
        {
            _postService = postService;
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> Index()
        {
            return await _postRepository.GetPostsAsync();
        }

        [HttpGet("FeaturedArticle")]
        public async Task<IActionResult> GetFeaturedArticle()
        {
            var posts = await _postService.GetPostItemByType(PostType.FeaturedArticle);
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts.ToList().FirstOrDefault());
        }

        [HttpGet("FeaturedNews")]
        public async Task<IActionResult> GetFeaturedNews()
        {
            var posts = await _postService.GetPostItemByType(PostType.FeaturedNews);
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts.ToList().FirstOrDefault());
        }
    }
}