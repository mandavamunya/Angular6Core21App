using Application.Core.Enums;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Core.Entities
{
    public class Post: TrackEntity
    {
        private Blog _blog;

        public Post()
        {
        }

        private Post(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }

        public Post(
            string title, 
            string description, 
            string content, 
            int views, 
            int publications,
            PostType type)
        {
            Title = title;
            Description = description;
            Content = content;
            Views = views;
            Publications = publications;
            Type = type;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public int Comments { get; set; }
        public int Publications { get; set; }
        public PostType Type { get; set; }

        public int BlogId { get; set; }

        public Blog Blog
        {
            get => LazyLoader.Load(this, ref _blog);
            set => _blog = value;
        }
    }
}
