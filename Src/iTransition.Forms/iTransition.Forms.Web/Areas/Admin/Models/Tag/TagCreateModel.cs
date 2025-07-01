using System.ComponentModel.DataAnnotations;

namespace iTransition.Forms.Web.Areas.Admin.Models.Tag
{
    public class TagCreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}