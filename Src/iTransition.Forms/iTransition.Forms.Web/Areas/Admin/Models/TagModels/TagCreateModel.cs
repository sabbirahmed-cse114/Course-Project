using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Web.Areas.Admin.Models.TagModels
{
    public class TagCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}