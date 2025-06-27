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
            if (isDuplicateTopic)
            {
                await _formsUnitOfWork.TopicRepository.AddAsync(topic);
                await _formsUnitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("Topic is duplicate");
            }
        }
    }
}
