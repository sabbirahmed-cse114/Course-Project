using AutoMapper;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Web.Areas.Admin.Models.TemplateModels;
using Microsoft.AspNetCore.Mvc;

namespace iTransition.Forms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TemplateController : Controller
    {
        public readonly ILogger<TemplateController> _logger;
        public readonly IMapper _mapper;
        public readonly ITemplateManagementService _templateManagementService;
        public readonly ITopicManagementService _topicManagementService;
        public readonly ITagManagementService _tagManagementService;

        public TemplateController(ILogger<TemplateController> logger, 
            IMapper mapper, ITemplateManagementService templateManagementService, 
            ITopicManagementService topicManagementService,
            ITagManagementService tagManagementService)
        {
            _logger = logger;
            _mapper = mapper;
            _templateManagementService = templateManagementService;
            _topicManagementService = topicManagementService;
            _tagManagementService = tagManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var model = new TemplateCreateModel();

            var topic = await _topicManagementService.GetTopicListAsync();
            var tag = await _tagManagementService.GetTagListAsync();

            model.SetTopics(topic);
            model.SetTags(tag);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TemplateCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var template = _mapper.Map<Template>(model);
                template.Id = Guid.NewGuid();
                template.ImageUrl = null;
                template.Tag = model.TagId.HasValue ? _tagManagementService.GetTagAsync(model.TagId.Value).Result : null;
                template.Topic = model.TopicId.HasValue ? _topicManagementService.GetTopicAsync(model.TopicId.Value).Result : null;
                try
                {
                    await _templateManagementService.CreateTemplateAsync(template);
                    TempData["SuccessMessage"] = "Create template successfully.";
                    return RedirectToAction("Index");

                }
                catch (Exception ex)                 
                {
                    _logger.LogInformation(ex, "Template creation failed...");
                    TempData["ErrorMessage"] = "Failed to created tag.";
                    return RedirectToAction("Create");
                }
            }
            else
            {
                var topic = await _topicManagementService.GetTopicListAsync();
                var tag = await _tagManagementService.GetTagListAsync();

                model.SetTopics(topic);
                model.SetTags(tag);
                return View(model);
            }                
        }
    }
}
