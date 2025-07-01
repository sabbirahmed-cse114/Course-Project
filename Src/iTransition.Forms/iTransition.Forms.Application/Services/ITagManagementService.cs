using iTransition.Forms.Domain;
using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Application.Services
{
    public interface ITagManagementService
    {
        Task CreateNewTagAsync(Tag tag);
        Task<(IList<Tag> data, int total, int totalDisplay)> GetTagsAsync(
            int pageIndex, int pageSize, DataTablesSearch search, string? order);
        Task<Tag> GetTagAsync(Guid id);
        Task UpdateTagAsync(Tag tag);
        Task DeleteTagAsync(Guid id);
    }
}
