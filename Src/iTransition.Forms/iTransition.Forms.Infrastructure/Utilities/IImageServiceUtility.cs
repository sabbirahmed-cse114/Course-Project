using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTransition.Forms.Infrastructure.Utilities
{
    public interface IImageServiceUtility
    {
        Task<string?> UploadImage(IFormFile? picture);
    }
}
