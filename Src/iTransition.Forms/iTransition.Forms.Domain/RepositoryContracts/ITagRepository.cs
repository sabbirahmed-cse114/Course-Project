using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Domain.RepositoryContracts
{
    public interface ITagRepository : IRepositoryBase<Tag, Guid>
    {
        bool IsTagNameDuplicate(string Name, Guid? id = null);
        Task<(IList<Tag> data, int total, int totalDisplay)> GetPagedTagsAsync(int pageIndex, int pageSize, DataTablesSearch search, string? order);
        Task<IList<Tag>> GetOrderedTagsAsync();
    }
}