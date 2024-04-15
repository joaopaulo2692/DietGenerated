using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dieta.API.DietaContext
{
    public class HomeController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
    }
}
