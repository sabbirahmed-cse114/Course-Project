using iTransition.Forms.Domain;
using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Application.Services
{
    public interface ITopicManagementService
    {
        Task CreateNewTopicAsync(Topic topic);
        Task<(IList<Topic> data, int total, int totalDisplay)> GetTopicsAsync(
            int pageIndex, int pageSize, DataTablesSearch search, string? order);
        Task DeleteTopicAsync(Guid id);
    }
}
