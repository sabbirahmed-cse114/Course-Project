using AutoMapper;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Web.Areas.Admin.Models.TopicModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace iTransition.Forms.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]
    public class TopicController : Controller
    {
        private readonly ILogger<TopicController> _logger;
        private readonly ITopicManagementService _topicManagementService;
        private readonly IMapper _mapper;

        public TopicController(ITopicManagementService topicManagementService, 
            ILogger<TopicController> logger, IMapper mapper)
        {
            _topicManagementService = topicManagementService;
            _logger = logger;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetTopicJsonData([FromBody] TopicListModel model)
        {
            var result = await _topicManagementService.GetTopicsAsync(
                model.PageIndex,
                model.PageSize,
                model.Search,
                model.FormatSortExpression("Name"));

            var topicJsonData = new
            {
                recordsTotal = result.total,
                recordsFiltered = result.totalDisplay,
                data = (from records in result.data
                        select new string[]
                            {
                                HttpUtility.HtmlEncode(records.Name),
                                records.Id.ToString()
                            }
                        ).ToArray()
            };
            return Json(topicJsonData);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TopicCreateModel model)
        {
            var topic = _mapper.Map<Topic>(model);
            topic.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                try
                {
                    await _topicManagementService.CreateNewTopicAsync(topic);
                    TempData["SuccessMessage"] = "Create topic successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex, "Topic created failed...");
                    TempData["ErrorMessage"] = "Failed to created topic.";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _topicManagementService.DeleteTopicAsync(id);
                TempData["SuccessMessage"] = "Delete topic successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Topic deleted failed...");
                TempData["ErrorMessage"] = "Failed to delete topic.";
                return RedirectToAction("Index");
            }
        }
    }
}