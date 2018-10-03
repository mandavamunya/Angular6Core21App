using Application.Core.Entities;
using Application.Core.Exceptions;
using Application.Core.Interfaces;
using Application.Core.Services;
using Moq;
using System;
using Xunit;

namespace UnitTests.Application.Core.ServicesTests
{
    public class SetPost
    {
        private int _invalidId = -1;
        private Mock<IAsyncRepository<Post>> _mockPostRepo;

        public SetPost()
        {
            _mockPostRepo = new Mock<IAsyncRepository<Post>>();
        }

        [Fact]
        public async void ThrowsGivenInvalidPostId()
        {
            var postService = new PostService(null, _mockPostRepo.Object);

            await Assert.ThrowsAsync<PostNotFoundException>(
                async () => await postService.GetPostById(_invalidId)
            );
        }

        [Fact]
        public async void ThrowsGivenNullPostServiceArguments()
        {
            var postService = new PostService(null, _mockPostRepo.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await postService.SetPostAsync(null)
            );
        }

    }
}
