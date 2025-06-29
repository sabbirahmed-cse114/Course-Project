using AutoMapper;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Infrastructure.Extensions;
using iTransition.Forms.Web.Models;
using iTransition.Forms.Web.Models.Topic;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace iTransition.Forms.Web.Controllers
{
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

                    TempData.Put("ResponseMessage", new ResponseModel()
                    {
                        Message = "Topic created Successfully",
                        Type = ResponseTypes.Success
                    });
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex, "Topic created failed...");
                    TempData.Put("ResponseMessage", new ResponseModel()
                    {
                        Message = "Topic creation failed",
                        Type = ResponseTypes.Danger
                    });
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
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Topic deleted successfully",
                    Type = ResponseTypes.Success
                });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Topic deleted failed...");
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Topic Delete failed",
                    Type = ResponseTypes.Danger
                });
                return RedirectToAction("Index");
            }
        }
    }
}