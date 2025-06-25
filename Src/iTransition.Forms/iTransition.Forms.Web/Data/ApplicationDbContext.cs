using iTransition.Forms.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iTransition.Forms.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
                                        <ApplicationUser, ApplicationRole, Guid,
                                        ApplicationUserClaim, ApplicationUserRole,
                                        ApplicationUserLogin, ApplicationRoleClaim,
                                        ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}