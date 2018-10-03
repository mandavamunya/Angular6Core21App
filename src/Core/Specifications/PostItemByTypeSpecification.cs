using Application.Core.Entities;
using Application.Core.Enums;

namespace Application.Core.Specifications
{
    public class PostItemByTypeSpecification : BaseSpecification<Post>
    {
        public PostItemByTypeSpecification(PostType postType)
            : base(p => p.Type == postType)
        {

        }
    }
}
