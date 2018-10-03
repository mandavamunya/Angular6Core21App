using System;

namespace Application.Core.Entities
{
    public class TrackEntity: BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
