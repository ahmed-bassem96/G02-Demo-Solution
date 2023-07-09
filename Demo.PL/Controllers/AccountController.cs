using Demo.DAL.Entities;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountController(UserManager<ApplicationUser> userManager) {
			_userManager = userManager;
		}
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
            if(ModelState.IsValid)
            {
                var User = new ApplicationUser()
                {
                    UserName = model.Email.Split('.')[0],
                    Email= model.Email,
                    IsAgree=model.IsAgree,
                    Fname=model.Fname,
                    Lname=model.Lname,
                };
             var Result=await _userManager.CreateAsync(User,model.Password);

                if (Result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                foreach(var Error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, Error.Description);
                }
            }
			return View(model);
		}

        public IActionResult Login() 
        {

            return View(); 
        }
	}
}
