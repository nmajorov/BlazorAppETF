
using BlazorAppETF.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorAppETF.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(
                UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signinManager
            )
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

      

       
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]User login)
        {
            

            
            Console.WriteLine($"find first user by name: {login}");
   
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null) return BadRequest("User does not exist");
            
            //
            // if(!ModelState.IsValid)
            // {
            //     return Redirect(returnUrl);
            // }

            var result = await _signinManager.PasswordSignInAsync(
                login.UserName, login.PasswordHash,
                login.RememberMe, false
            );

            Console.WriteLine($"singInAsyncResult: {result.Succeeded}");

            if(!result.Succeeded)
            {
                return BadRequest("Invalid password");

//                ModelState.AddModelError("", "Login error!");
  //              return Redirect(returnUrl);
            }


            return Ok();
        }

        
        [Route("Logout")]
        [HttpPost]
        public async Task<IActionResult> Logout(string? returnUrl = null)
        {
            await _signinManager.SignOutAsync();

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToPage("/Index");

            return Redirect(returnUrl);
        }


        /**
         
         
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            Console.Out.WriteLine("enter register");
            
            if (!ModelState.IsValid)
                return View(registration);

            var newUser = new IdentityUser
            {
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress,
            };

            var result = await _userManager.CreateAsync(newUser, registration.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                
                return View();
            }

            return RedirectToAction("Login");
        }
        **/
    }
}
