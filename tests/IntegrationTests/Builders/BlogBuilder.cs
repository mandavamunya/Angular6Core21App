using Application.Core.Entities;
using Infrastructure.Data;

namespace IntegrationTests.Builders
{
    public class BlogBuilder
    {
        private static BlogBuilder _instance;
        public static BlogBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BlogBuilder(); 
                }
                return _instance;
            }
        }

        public Blog DummyBlog()
        {
            return SampleBlogData.Instance.Blogs[0];       
        }
    }
}
