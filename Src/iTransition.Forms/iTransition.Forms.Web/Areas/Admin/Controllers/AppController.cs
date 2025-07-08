using AutoMapper;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Web.Areas.Admin.Models.TemplateModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTransition.Forms.Web.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class AppController : Controller
    {
        private readonly ILogger<AppController> _logger;
        private readonly IMapper _mapper;
        private readonly ITopicManagementService _topicManagementService;
        private readonly ITagManagementService _tagManagementService;
        private readonly ITemplateManagementService _templateManagementService;

        public AppController(ILogger<AppController> logger, IMapper mapper, 
            ITopicManagementService topicManagementService, 
            ITagManagementService tagManagementService, 
            ITemplateManagementService templateManagementService)
        {
            _logger = logger;
            _mapper = mapper;
            _topicManagementService = topicManagementService;
            _tagManagementService = tagManagementService;
            _templateManagementService = templateManagementService;
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var model = new TemplateListModel();

            var topics = await _topicManagementService.GetTopicListAsync();
            var tags = await _tagManagementService.GetTagListAsync();
            var topTemplates = await _templateManagementService.GetTopPopularTemplatesAsync(9);

            model.SetTopics(topics);
            model.SetTags(tags);
            model.TopTemplates = topTemplates;

            return View(model);
        }
    }
}
