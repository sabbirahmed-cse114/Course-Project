using AutoMapper;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Infrastructure.Extensions;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Web.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult Create()
        {
            var model = new TopicCreateModel();
            return View(model);
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
    }
}
