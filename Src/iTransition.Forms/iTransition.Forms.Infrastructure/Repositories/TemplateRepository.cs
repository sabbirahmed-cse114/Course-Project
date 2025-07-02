using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Domain.RepositoryContracts;

namespace iTransition.Forms.Infrastructure.Repositories
{
    public class TemplateRepository : Repository<Template,Guid>, ITemplateRepository
    {
        public TemplateRepository(ApplicationDbContext context): base(context) { }

        public bool IsTemplateNameDuplicate(string name, Guid? id = null)
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
