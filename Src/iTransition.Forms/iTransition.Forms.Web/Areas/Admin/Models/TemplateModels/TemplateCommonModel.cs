using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Web.Areas.Admin.Models.TemplateModels
{
    public class TemplateCommonModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsPublic { get; set; }

        [Display(Name = "Topics")]
        public Guid? TopicId { get; set; }
        public IList<SelectListItem>? Topics { get; private set; }

        [Display(Name = "Tags")]
        public Guid? TagId { get; set; }
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
