using CodeAcademyCompany.DAL.Model;
using CodeAcademyCompany.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeAcademyCompany.PL.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<ApplicationUser>  _userManager;
		private readonly SignInManager<ApplicationUser> _signinManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
			_userManager = userManager;
			_signinManager = signinManager;
		}
        #region Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm model)
        { 
			if (ModelState.IsValid)
            {
                var User = new ApplicationUser()
                { UserName = model.Email.Split('@')[0],
                    Fname = model.Fname ,
                    Lname = model.Lname ,
                    //UserName = model.Fname + model.Lname ,
                    Email = model.Email ,

                };
                var result = await _userManager.CreateAsync(User, model.Password);
                if(result.Succeeded)
                {
                      return  RedirectToAction("Login");  
                }
                else
                {
                    foreach(var err in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, err.Description);
                    }
                }

                
            }

            return View(model);
        }

        #endregion
        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Login(LoginVM model)
		{
            if (ModelState.IsValid)
            {
                var user =await _userManager .FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
					{                      //ginerate Token
						var reselt = await _signinManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (reselt.Succeeded) { 
                            return RedirectToAction("Index", "Employee"); 
                        }
                            
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Password not valid");

					}
                }
				ModelState.AddModelError(string.Empty, "Email not valid ");

			}
			return View(model);
		}

		#endregion

	}
}
