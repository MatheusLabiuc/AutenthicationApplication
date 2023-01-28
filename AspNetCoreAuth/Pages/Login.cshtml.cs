using AspNetCoreAuth.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AspNetCoreAuth.Pages
{
    public class LoginModel : PageModel
    {

        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]        
        public LogModel Model { get; set; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
           this.signInManager = signInManager;
        }

        public void Onget()
        {

        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
               var identityResult =  await signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    if(returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {

                        return RedirectToPage(returnUrl);
                    }
                }

                ModelState.AddModelError("", "username or password");
                
            }
            return Page();

        }

        
    }

}