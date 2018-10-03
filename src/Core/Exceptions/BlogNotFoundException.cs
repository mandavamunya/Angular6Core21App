using Application.Core.Entities;
using System;
using System.Runtime.Serialization;

namespace Application.Core.Exceptions
{
    public class BlogNotFoundException : Exception
    {
        public BlogNotFoundException(int blogId) 
            : base($"No blog found with id {blogId}")
        {
        }

        protected BlogNotFoundException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }

        public BlogNotFoundException(string message) 
            : base(message)
        {
        }

        public BlogNotFoundException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
