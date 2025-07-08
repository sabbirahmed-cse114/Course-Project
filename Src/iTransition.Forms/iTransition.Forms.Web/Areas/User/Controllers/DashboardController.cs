using iTransition.Forms.Application.Services;
using iTransition.Forms.Web.Areas.Admin.Models.TemplateModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTransition.Forms.Web.Areas.User.Controllers
{
    [Area("User"),Authorize]
    public class DashboardController : Controller
    {
        public readonly ILogger<DashboardController> logger;
        public readonly ITopicManagementService _topicManagementService;
        public readonly ITagManagementService _tagManagementService;
        public readonly ITemplateManagementService _templateManagementService;

        public DashboardController(ILogger<DashboardController> logger, 
            ITopicManagementService topicManagementService, 
            ITagManagementService tagManagementService, 
            ITemplateManagementService templateManagementService)
        {
            this.logger = logger;
            _topicManagementService = topicManagementService;
            _tagManagementService = tagManagementService;
            _templateManagementService = templateManagementService;
        }

        [HttpGet, Authorize(Roles = "Admin,User")]
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
