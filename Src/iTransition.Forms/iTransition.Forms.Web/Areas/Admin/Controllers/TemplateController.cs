using AutoMapper;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Infrastructure.Utilities;
using iTransition.Forms.Web.Areas.Admin.Models.TemplateModels;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace iTransition.Forms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TemplateController : Controller
    {
        private readonly ILogger<TemplateController> _logger;
        private readonly IMapper _mapper;
        private readonly ITemplateManagementService _templateManagementService;
        private readonly ITopicManagementService _topicManagementService;
        private readonly ITagManagementService _tagManagementService;
        private readonly IImageServiceUtility _imageServiceUtility;

        public TemplateController(ILogger<TemplateController> logger,
            IMapper mapper, ITemplateManagementService templateManagementService,
            ITopicManagementService topicManagementService,
            ITagManagementService tagManagementService,
            IImageServiceUtility imageServiceUtility)
        {
            _logger = logger;
            _mapper = mapper;
            _templateManagementService = templateManagementService;
            _topicManagementService = topicManagementService;
            _tagManagementService = tagManagementService;
            _imageServiceUtility = imageServiceUtility;
        }

        [HttpGet]
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


        public async Task<IActionResult> Create()
        {
            var model = new TemplateCreateModel();

            var topic = await _topicManagementService.GetTopicListAsync();
            model.SetTopics(topic);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TemplateCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var imageUrl = await _imageServiceUtility.UploadImage(model.picture);
                var template = _mapper.Map<Template>(model);
                template.Id = Guid.NewGuid();
                template.ImageUrl = imageUrl;
                template.Topic = _topicManagementService.GetTopicAsync(model.TopicId).Result;
                template.CreatedAt = DateTime.UtcNow;

                if (model.TagIds != null && model.TagIds.Any())
                {
                    template.TemplateTags = model.TagIds.Select(tagId => new TemplateTag
                    {
                        TemplateId = template.Id,
                        TagId = tagId
                    }).ToList();
                }
                try
                {
                    await _templateManagementService.CreateTemplateAsync(template);
                    TempData["SuccessMessage"] = "Create template successfully.";
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex, "Template creation failed...");
                    TempData["ErrorMessage"] = "Failed to created template.";
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

        [HttpGet]
        public async Task<JsonResult> GetTagsByAutocompleteSearch(string term)
        {
            var tags = await _tagManagementService.GetTagListAsync();
            var matched = tags.Where(t => t.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
                .Select(t => new { label = t.Name, id = t.Id }).ToList();
            return Json(matched);
        }
    }
}