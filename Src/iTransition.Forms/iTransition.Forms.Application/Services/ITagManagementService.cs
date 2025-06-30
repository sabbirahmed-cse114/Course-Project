using iTransition.Forms.Domain;
using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Application.Services
{
    public interface ITagManagementService
    {
        Task CreateNewTagAsync(Topic topic);
        Task<(IList<Tag> data, int total, int totalDisplay)> GetTagsAsync(
            int pageIndex, int pageSize, DataTablesSearch search, string? order);
        Task DeleteTagAsync(Guid id);
    }
}
