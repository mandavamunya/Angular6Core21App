using Application.Core.Entities;
using Xunit;

namespace UnitTests.Application.Core.Entities
{
    public class AddBlog
    {
        private string _name = "Publication";
        private bool _isPublished = true;

        [Fact]
        public void AddsBlogIfNotPresent()
        {
            var blog = new Blog(_name, _isPublished);
            Assert.Equal(_name, blog.Name);
            Assert.Equal(_isPublished, blog.IsPublished);
        }
    }
}
