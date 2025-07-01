using iTransition.Forms.Domain;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Domain.RepositoryContracts;

namespace iTransition.Forms.Infrastructure.Repositories
{
    public class TopicRepository : Repository<Topic, Guid>, ITopicRepository
    {
        public TopicRepository(ApplicationDbContext context) : base(context) { }

        public bool IsTopicNameDuplicate(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                return GetCount(x => !x.Id.Equals(id.Value) && x.Name.Equals(name)) > 0;
            }
            else
            {
                return GetCount(x => x.Name.Equals(name)) > 0;
            }
        }

        public async Task<(IList<Topic> data, int total, int totalDisplay)> GetPagedTopicsAsync(int pageIndex, int pageSize, DataTablesSearch search, string? order)
        {
            var searchText = search.Value;
            if (string.IsNullOrWhiteSpace(searchText))
                return await GetDynamicAsync(null, order, null, pageIndex, pageSize, true);

            return await GetDynamicAsync(x => x.Name.Contains(searchText), order, null, pageIndex, pageSize, true);
        }
    }
}
