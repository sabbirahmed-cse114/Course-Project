using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Web.Areas.Admin.Models.TagModels
{
    public class TagUpdateModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
