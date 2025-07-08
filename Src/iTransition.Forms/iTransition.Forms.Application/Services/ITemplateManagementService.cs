using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Application.Services
{
    public interface ITemplateManagementService
    {
        Task CreateTemplateAsync(Template template);
        Task<IList<Template>> GetTopPopularTemplatesAsync(int? count = null);
    }
}
