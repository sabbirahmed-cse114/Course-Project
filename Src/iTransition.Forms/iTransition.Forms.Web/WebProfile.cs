using AutoMapper;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Web.Areas.Admin.Models.Topic;
using iTransition.Forms.Web.Areas.Admin.Models.Tag;

namespace iTransition.Forms.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<TopicCreateModel, Topic>().ReverseMap();
            CreateMap<TagCreateModel, Tag>().ReverseMap();
        }
    }
}
