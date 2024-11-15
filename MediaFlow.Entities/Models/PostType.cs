using MediaFlow.Core.Abstract;

namespace MediaFlow.Entities.Models
{
    public class PostType : IEntity
    {
        public int PostTypeId { get; set; }
        public string? TypeName { get; set; } // e.g., Text, Image, Video

        // Navigation Properties
        public ICollection<ContentPost>? ContentPosts { get; set; }
    }

}
