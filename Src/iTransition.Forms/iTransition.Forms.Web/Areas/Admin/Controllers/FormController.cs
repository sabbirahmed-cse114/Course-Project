using AutoMapper;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Web.Areas.Admin.Models.FormModels;
using Microsoft.AspNetCore.Mvc;

namespace iTransition.Forms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FormController : Controller
    {
        public readonly ILogger<FormController> _logger;
        public readonly IMapper _mapper;
        private readonly ITemplateManagementService _templateManagementService;

        public FormController(ILogger<FormController> logger, IMapper mapper,
            ITemplateManagementService templateManagementService)
        {
            _logger = logger;
            _mapper = mapper;
            _templateManagementService = templateManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFromTemplate(Guid templateId)
        {
            //var template = await _templateManagementService.GetTemplateByIdAsync(templateId);
            //if (template == null) return NotFound();

            //var model = new FormCreateModel
            //{
            //    TemplateId = template.Id,
            //    TopicId = template.TopicId,
            //    TagId = template.TagId,
            //};

            return View("Create","model");
        }

    }
}
