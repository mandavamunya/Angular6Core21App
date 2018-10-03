using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Core.Entities;
using Application.Core.Enums;
using Application.Core.Interfaces;
using Application.Core.Specifications;
using Ardalis.GuardClauses;

namespace Application.Core.Services
{
    public class PostService: IPostService
    {
        private readonly IAppLogger<PostService> _logger;
        private readonly IAsyncRepository<Post> _postRepository;

        public PostService(
            IAppLogger<PostService> logger,
            IAsyncRepository<Post> postRepository
            )
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public async Task CreatePostAsync(Post post)
        {
            await _postRepository.AddAsync(post);
        }

        public async Task DeletePostAsync(Post post)
        {
            await _postRepository.DeleteAsync(post);
        }

        public async Task<Post> GetPostById(int postId)
        {
            var post = await _postRepository.GetByIdAsync(postId);
            Guard.Against.NullPost(postId, post);
            return post;
        }

        public async Task SetPostAsync(Post post)
        {
            Guard.Against.Null(post, nameof(post));
            await _postRepository.UpdateAsync(post);
        }

        public async Task<IEnumerable<Post>> GetPostItemByType(PostType postType)
        {
            var spec = new PostItemByTypeSpecification(postType);
            return await _postRepository.ListAsync(spec);
        }
    }
}
