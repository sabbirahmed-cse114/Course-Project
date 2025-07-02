
namespace iTransition.Forms.Domain.Entities
{
    public class Template : IEntity<Guid>
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPublic { get; set; }

        public Guid? TopicId { get; set; }
        public Topic? Topic { get; set; }

        public Guid? TagId { get; set; }
        public Tag? Tag { get; set; }

        public List<TemplateTag>? TemplateTags { get; set; }
    }
}
