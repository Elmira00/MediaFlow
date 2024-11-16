using MediaFlow.Core.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MediaFlow.Entities.Models
{
    public class PostType : IEntity
    {
        [Key]
        public int PostTypeId { get; set; }
        public string? TypePlatformName { get; set; } // e.g., Text, Image, Video

        // Navigation Properties
        public ICollection<ContentPost>? ContentPosts { get; set; }
    }

}
