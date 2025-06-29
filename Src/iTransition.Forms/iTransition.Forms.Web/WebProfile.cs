using AutoMapper;
using iTransition.Forms.Domain.Entities;
using iTransition.Forms.Web.Models.Topic;

namespace iTransition.Forms.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<TopicCreateModel, Topic>().ReverseMap();
        }
    }
}
