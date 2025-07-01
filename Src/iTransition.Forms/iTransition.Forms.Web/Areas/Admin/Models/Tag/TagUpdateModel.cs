using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Web.Areas.Admin.Models.Tag
{
    public class TagUpdateModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
