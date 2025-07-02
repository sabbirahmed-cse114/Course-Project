using iTransition.Forms.Application;
using iTransition.Forms.Domain.RepositoryContracts;

namespace iTransition.Forms.Infrastructure.UnitOfWorks
{
    public class FormsUnitOfWork : UnitOfWork, IFormsUnitOfWork
    {
        public ITopicRepository TopicRepository { get; private set; }
        public ITagRepository TagRepository { get; private set; }
        public ITemplateRepository TemplateRepository { get; private set; }

        public FormsUnitOfWork(ApplicationDbContext dbContext,
            ITopicRepository topicRepository,
            ITagRepository tagRepository,
            ITemplateRepository templateRepository) : base(dbContext)
        {
            TopicRepository = topicRepository;
            TagRepository = tagRepository;
            TemplateRepository = templateRepository;
        }
    }
}