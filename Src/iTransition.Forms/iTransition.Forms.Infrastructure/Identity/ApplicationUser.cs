using Microsoft.AspNetCore.Identity;

namespace iTransition.Forms.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
    }
}
