using iTransition.Forms.Domain;
using iTransition.Forms.Domain.RepositoryContracts;

namespace iTransition.Forms.Application
{
    public interface IFormsUnitOfWork : IUnitOfWork
    {
        public ITopicRepository TopicRepository { get; }
    }
}
