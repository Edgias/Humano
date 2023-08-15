using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Edgias.Humano.Infrastructure.Identity;

namespace Edgias.Humano.WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        [Required]
        [BindProperty]
        public string? Email { get; set; }

        [Required]
        [BindProperty]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginModel(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser user = await _userManager.FindByNameAsync(Email);

            if (user == null)
            {
                return NotFound();
            }

            if (!user.EmailConfirmed)
            {
                // Handle unconfirmed emails.
            }

            Microsoft.AspNetCore.Identity.SignInResult response =
                await _signInManager.PasswordSignInAsync(user, Password, RememberMe, true);

            if (response.Succeeded)
            {
                //return RedirectToPage("/Index");
                return LocalRedirect(returnUrl);
            }

            if (response.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new
                {
                    ReturnUrl = returnUrl,
                    RememberMe
                });
            }

            if (response.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

        }
    }
}
