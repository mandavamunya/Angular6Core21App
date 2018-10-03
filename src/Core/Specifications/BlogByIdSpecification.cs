using Application.Core.Entities;

namespace Application.Core.Specifications
{
    public class BlogByIdSpecification: BaseSpecification<Blog>
    {
        public BlogByIdSpecification(int blogId)
            : base(b => b.Id == blogId)
        {
            AddInclude(b => b.Posts);
        }
    }
}
