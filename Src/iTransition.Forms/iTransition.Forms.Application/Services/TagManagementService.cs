using iTransition.Forms.Domain;
using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Application.Services
{
    public class TagManagementService : ITagManagementService
    {
        private readonly IFormsUnitOfWork _formsUnitOfWork;
        public TagManagementService(IFormsUnitOfWork formsUnitOfWork)
        {
            _formsUnitOfWork = formsUnitOfWork;
        }

        public async Task CreateNewTagAsync(Topic topic)
        {
            var isDuplicateTag = _formsUnitOfWork.TopicRepository.IsTopicNameDuplicate(topic.Name);
            if (!isDuplicateTag)
            {
                await _formsUnitOfWork.TopicRepository.AddAsync(topic);
                await _formsUnitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("Tag is duplicate");
            }
        }

        public async Task<(IList<Tag> data, int total, int totalDisplay)> GetTagsAsync(int pageIndex, int pageSize, DataTablesSearch search, string? order)
        {
            return await _formsUnitOfWork.TagRepository.GetPagedTagsAsync(
                pageIndex, pageSize, search, order);
        }

        public async Task DeleteTagAsync(Guid id)
        {
            await _formsUnitOfWork.TopicRepository.RemoveAsync(id);
            await _formsUnitOfWork.SaveAsync();
        }
    }
}
