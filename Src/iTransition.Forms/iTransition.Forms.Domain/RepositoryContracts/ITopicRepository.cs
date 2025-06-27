using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Domain.RepositoryContracts
{
    public interface ITopicRepository : IRepositoryBase<Topic, Guid>
    {
        bool IsTopicNameDuplicate(string Name, Guid? id = null);
    }
}
