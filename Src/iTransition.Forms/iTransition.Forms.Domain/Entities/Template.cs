
using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Domain.Entities
{
    public class Template : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPublic { get; set; }
        public int UsesCount { get; set; }
        public Guid? TopicId { get; set; }
        public Topic? Topic { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<TemplateTag>? TemplateTags { get; set; }
    }
}
