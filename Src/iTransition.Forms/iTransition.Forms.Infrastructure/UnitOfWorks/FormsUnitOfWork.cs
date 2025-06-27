using iTransition.Forms.Application;
using iTransition.Forms.Domain.RepositoryContracts;

namespace iTransition.Forms.Infrastructure.UnitOfWorks
{
    public class FormsUnitOfWork : UnitOfWork, IFormsUnitOfWork
    {
        public ITopicRepository TopicRepository { get; private set; }

        public FormsUnitOfWork(ApplicationDbContext dbContext,
            ITopicRepository topicRepository) : base(dbContext)
        {
            TopicRepository = topicRepository;
        }
    }
}