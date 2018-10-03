using Application.Core.Entities;
using Application.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetPostById(int postId);
        Task<IEnumerable<Post>> GetPostItemByType(PostType postType);
        Task CreatePostAsync(Post post);
        Task SetPostAsync(Post post);
        Task DeletePostAsync(Post post);
    }
}
