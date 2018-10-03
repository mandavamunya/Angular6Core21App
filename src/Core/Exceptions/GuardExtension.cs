using Application.Core.Entities;
using Application.Core.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class GuardExtension
    {
        public static void NullBlog(this IGuardClause guardClause, int blogId, Blog blog)
        {
            if (blog == null)
                throw new BlogNotFoundException(blogId);
        }

        public static void NullPost(this IGuardClause guardClause, int postId, Post post)
        {
            if (post == null)
                throw new PostNotFoundException(postId);
        }
    }
}
