using Application.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Core.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs();
        Task<IEnumerable<Blog>> GetBlogsAsync();
    }
}
