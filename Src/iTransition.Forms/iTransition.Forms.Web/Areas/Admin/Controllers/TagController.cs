using AutoMapper;
using iTransition.Forms.Application.Services;
using iTransition.Forms.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using iTransition.Forms.Web.Areas.Admin.Models.Tag;

namespace iTransition.Forms.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly ILogger<TagController> _logger;
        private readonly ITagManagementService _tagManagementService;
        private readonly IMapper _mapper;

        public TagController(ITagManagementService tagManagementService, 
            ILogger<TagController> logger, IMapper mapper)
        {
            _tagManagementService = tagManagementService;
            _logger = logger;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetTagJsonData([FromBody] TagListModel model)
        {
            var result = await _tagManagementService.GetTagsAsync(
                model.PageIndex,
                model.PageSize,
                model.Search,
                model.FormatSortExpression("Name"));

            var tagJsonData = new
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
            return Json(tagJsonData);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TagCreateModel model)
        {
            var tag = _mapper.Map<Tag>(model);
            tag.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                try
                {
                    await _tagManagementService.CreateNewTagAsync(tag);
                    TempData["SuccessMessage"] = "Create tag successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex, "Tag created failed...");
                    TempData["ErrorMessage"] = "Failed to created tag.";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _tagManagementService.DeleteTagAsync(id);
                TempData["SuccessMessage"] = "Tag delete successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Tag deleted failed...");
                TempData["ErrorMessage"] = "Failed to delete tag.";
                return RedirectToAction("Index");
            }
        }
    }
}