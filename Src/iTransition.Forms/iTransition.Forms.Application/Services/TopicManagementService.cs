using iTransition.Forms.Domain;
using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Application.Services
{
    public class TopicManagementService : ITopicManagementService
    {
        private readonly IFormsUnitOfWork _formsUnitOfWork;
        public TopicManagementService(IFormsUnitOfWork formsUnitOfWork)
        {
            _formsUnitOfWork = formsUnitOfWork;
        }

        public async Task CreateNewTopicAsync(Topic topic)
        {
            var isDuplicateTopic = _formsUnitOfWork.TopicRepository.IsTopicNameDuplicate(topic.Name);
            if (!isDuplicateTopic)
            {
                await _formsUnitOfWork.TopicRepository.AddAsync(topic);
                await _formsUnitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("Topic is duplicate");
            }
        }

        public async Task<(IList<Topic> data, int total, int totalDisplay)> GetTopicsAsync(int pageIndex, int pageSize, DataTablesSearch search, string? order)
        {
            return await _formsUnitOfWork.TopicRepository.GetPagedTopicsAsync(
                pageIndex, pageSize, search, order);
        }

        public async Task DeleteTopicAsync(Guid id)
        {
            await _formsUnitOfWork.TopicRepository.RemoveAsync(id);
            await _formsUnitOfWork.SaveAsync();
        }
    }
}
