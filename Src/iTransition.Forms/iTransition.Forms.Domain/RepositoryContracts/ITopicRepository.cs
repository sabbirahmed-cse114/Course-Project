using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Domain.RepositoryContracts
{
    public interface ITopicRepository : IRepositoryBase<Topic, Guid>
    {
        bool IsTopicNameDuplicate(string Name, Guid? id = null);
        Task<(IList<Topic> data, int total, int totalDisplay)> GetPagedTopicsAsync(int pageIndex, int pageSize, DataTablesSearch search, string? order);

    }
}
