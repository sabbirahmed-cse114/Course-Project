using iTransition.Forms.Domain.Entities;

namespace iTransition.Forms.Application.Services
{
    public class TemplateManagementService : ITemplateManagementService
    {
        private readonly IFormsUnitOfWork _formsUnitOfWork;
        public TemplateManagementService(IFormsUnitOfWork formsUnitOfWork)
        {
            _formsUnitOfWork = formsUnitOfWork;
        }

        public async Task CreateTemplateAsync(Template template)
        {
            var isTemplateNameDuplicate = _formsUnitOfWork.TemplateRepository.IsTemplateNameDuplicate(template.Name);
            if(!isTemplateNameDuplicate)
            {
                _formsUnitOfWork.TemplateRepository.AddAsync(template);
                _formsUnitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("Template is duplicate");
            }
        }
    }
}
