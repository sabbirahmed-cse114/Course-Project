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

        public async Task CreateNewTagAsync(Tag tag)
        {
            var isDuplicateTag = _formsUnitOfWork.TagRepository.IsTagNameDuplicate(tag.Name);
            if (!isDuplicateTag)
            {
                await _formsUnitOfWork.TagRepository.AddAsync(tag);
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

        public async Task<Tag> GetTagAsync(Guid id)
        {
            return await _formsUnitOfWork.TagRepository.GetByIdAsync(id);
        }


        public async Task UpdateTagAsync(Tag tag)
        {
            if (!_formsUnitOfWork.TagRepository.IsTagNameDuplicate(tag.Name, tag.Id))
            {
                await _formsUnitOfWork.TagRepository.UpdateAsync(tag);
                await _formsUnitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("Tag name is duplicate");
            }
        }

        public async Task DeleteTagAsync(Guid id)
        {
            await _formsUnitOfWork.TagRepository.RemoveAsync(id);
            await _formsUnitOfWork.SaveAsync();
        }
    }
}
