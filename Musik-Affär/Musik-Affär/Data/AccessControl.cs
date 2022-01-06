using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Musik_Affär.Models;

namespace Musik_Affär.Data
{
    public class AccessControl
    {
        public string LoggedInUserID { get; private set; }
        public bool LoggedIn { get; private set; }

        public AccessControl(UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            LoggedInUserID = userManager.GetUserId(httpContextAccessor.HttpContext.User);
            LoggedIn = httpContextAccessor.HttpContext.User != null;
        }

        public bool UserCanAcces(IdentityUser user)
        {
            return user.Id == LoggedInUserID;
        }    
    }
}
