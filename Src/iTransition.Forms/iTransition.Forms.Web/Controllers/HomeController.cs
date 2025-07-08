using iTransition.Forms.Application.Services;
using iTransition.Forms.Web.Areas.Admin.Models.TemplateModels;
using iTransition.Forms.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace iTransition.Forms.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITopicManagementService _topicManagementService;
        private readonly ITagManagementService _tagManagementService;
        private readonly ITemplateManagementService _templateManagementService;

        public HomeController(ILogger<HomeController> logger,
            ITopicManagementService topicManagementService,
            ITagManagementService tagManagementService,
            ITemplateManagementService templateManagementService)
        {
            _logger = logger;
            _topicManagementService = topicManagementService;
            _tagManagementService = tagManagementService;
            _templateManagementService = templateManagementService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = new TemplateListModel();

            var topics = await _topicManagementService.GetTopicListAsync();
            var tags = await _tagManagementService.GetTagListAsync();
            var topTemplates = await _templateManagementService.GetTopPopularTemplatesAsync(11);

            model.SetTopics(topics);
            model.SetTags(tags);
            model.TopTemplates = topTemplates;

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
