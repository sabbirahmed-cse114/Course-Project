namespace iTransition.Forms.Web.Areas.Admin.Models.FormModels
{
    public class FormCreateModel
    {
        public Guid TemplateId { get; set; }
        public Guid? TopicId { get; set; }
        public Guid? TagId { get; set; }
    }
}
