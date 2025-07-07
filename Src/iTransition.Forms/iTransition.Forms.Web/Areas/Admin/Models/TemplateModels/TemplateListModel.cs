using iTransition.Forms.Domain;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iTransition.Forms.Web.Areas.Admin.Models.TemplateModels
{
    public class TemplateListModel : DataTables
    {
        public IList<Template>? TopTemplates { get; set; }
        public IList<SelectListItem>? Topics { get; private set; }
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