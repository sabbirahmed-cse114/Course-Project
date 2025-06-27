using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Application.Services
{
    public interface ITopicManagementService
    {
        Task CreateNewTopicAsync(Topic topic);
    }
}
