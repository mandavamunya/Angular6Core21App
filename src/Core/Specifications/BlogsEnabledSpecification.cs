using Application.Core.Entities;

namespace Application.Core.Specifications
{
    public class BlogsEnabledSpecification : BaseSpecification<Blog>
    {
        public BlogsEnabledSpecification(bool isPublished)
            : base(b => b.IsPublished == isPublished)
        {
            AddInclude(b => b.Posts);
        }
    }
}
