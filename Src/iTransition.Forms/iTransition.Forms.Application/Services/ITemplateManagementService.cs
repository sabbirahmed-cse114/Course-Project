using iTransition.Forms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTransition.Forms.Application.Services
{
    public interface ITemplateManagementService
    {
        Task CreateTemplateAsync(Template template);
    }
}
