

using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Domain.RepositoryContracts
{
    public interface ITemplateRepository : IRepositoryBase<Template,Guid>
    {
        bool IsTemplateNameDuplicate(string Name, Guid? id = null);
    }
}
