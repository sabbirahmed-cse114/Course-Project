using AutoMapper;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Web.Areas.Admin.Models.TopicModels;
using iTransition.Forms.Web.Areas.Admin.Models.TagModels;
using iTransition.Forms.Web.Areas.Admin.Models.TemplateModels;

namespace iTransition.Forms.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<TopicCreateModel, Topic>().ReverseMap();

            CreateMap<TagCreateModel, Tag>().ReverseMap();
            CreateMap<TagUpdateModel, Tag>().ReverseMap();

            CreateMap<TemplateCreateModel, Template>().ReverseMap();
        }
    }
}
