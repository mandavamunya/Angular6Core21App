using Application.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPosts();
        Task<IEnumerable<Post>> GetPostsAsync();
    }
}
