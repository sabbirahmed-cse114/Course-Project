using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Domain.RepositoryContracts;
using System.Data.SqlClient;

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
    }
}
