using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Web.Areas.Admin.Models.TemplateModels
{
    public class TemplateCommonModel
    {
        [Required]
        [Display(Name = "Template Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile? picture { get; set; }

        [Required]
        [Display(Name = "Access Type")]
        public bool IsPublic { get; set; } = true;

        [Required]
        [Display(Name = "Topics")]
        public Guid TopicId { get; set; }
        public IList<SelectListItem>? Topics { get; private set; }

        [Required]
        [Display(Name = "Tags")]
        public List<Guid>? TagIds { get; set; }
        public IList<SelectListItem>? Tags { get; private set; }

        public void SetTopics(IList<Topic> topics)
        {
            Topics = topics.ToSelectList(x => x.Name, y => y.Id);
        }

        public void SetTags(IList<Tag> tags)
        {
            Tags = tags.ToSelectList(x => x.Name, y => y.Id);
        }
    }
}
