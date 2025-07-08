using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Web.Areas.Admin.Models.TopicModels
{
    public class TopicCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}