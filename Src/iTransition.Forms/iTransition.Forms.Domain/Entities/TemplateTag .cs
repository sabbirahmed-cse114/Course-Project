

namespace iTransition.Forms.Domain.Entities
{
    public class TemplateTag : ITagCompositEntity<Guid>
    {
        public Guid TemplateId { get; set; }
        public Template? Template { get; set; }
        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
