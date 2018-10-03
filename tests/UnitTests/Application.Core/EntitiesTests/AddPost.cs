using Application.Core.Entities;
using Application.Core.Enums;
using Xunit;

namespace UnitTests.Application.Core.Entities
{
    public class AddPost
    {
        private string _title = "Article title goes here.";
        private string _description = "Description goes here";
        private string _content = "A and B.";
        private int _views = 6747;
        private int _publications = 84;
        private PostType _type = PostType.Article;

        [Fact]
        public void AddsPostIfNotPresent()
        {
            var post = new Post(_title, _description, _content, _views, _publications, _type);
            Assert.Equal(_title, post.Title);
            Assert.Equal(_description, post.Description);
            Assert.Equal(_content, post.Content);
            Assert.Equal(_views, post.Views);
            Assert.Equal(_publications, post.Publications);
            Assert.Equal(_type, post.Type);
        }
    }
}
