using System;
using System.Runtime.Serialization;

namespace Application.Core.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(int postId) : base($"No post found with id {postId}")
        {
        }

        protected PostNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public PostNotFoundException(string message) : base(message)
        {
        }

        public PostNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
