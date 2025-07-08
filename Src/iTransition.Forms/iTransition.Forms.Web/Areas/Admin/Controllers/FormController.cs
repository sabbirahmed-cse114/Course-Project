using AutoMapper;
using iTransition.Forms.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTransition.Forms.Web.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> CreateFromTemplate()
        {
            return View("Index");
        }

    }
}
