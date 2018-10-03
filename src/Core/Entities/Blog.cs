using Application.Core.Enums;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;

namespace Application.Core.Entities
{
    public class Blog: TrackEntity
    {
        private ICollection<Post> _posts;

        public Blog()
        {
        }

        private Blog(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }

        public Blog(string name, bool isPublished)
        {
            Name = name;
            IsPublished = isPublished;
        }

        public string Name { get; set; }
        public PostType? PostType { get; set; }
        public bool IsPublished { get; set; }

        public ICollection<Post> Posts
        {
            get => LazyLoader.Load(this, ref _posts);
            set => _posts = value;
        }

    }
}
