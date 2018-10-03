using Application.Core.Enums;

namespace Application.Core.Entities
{
    public class BlogCategory: BaseEntity
    {
        public string Name { get; set; }
        public PostType Type { get; set; }
    }
}
