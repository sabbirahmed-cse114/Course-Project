
namespace iTransition.Forms.Domain.Entities
{
    public interface ITagCompositEntity<T>
    {
        T TagId { get; set; }
        T TemplateId { get; set; }
    }
}
