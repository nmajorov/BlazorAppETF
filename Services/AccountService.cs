
using BlazorAppETF.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorAppETF.Services
{
    public class AccountService 
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountService(
                UserManager<IdentityUser> userManager,
                SignInManager<IdentityUser> signinManager
            )
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }

      

       
       
        public async Task Login(User login)
        {
            
            Console.WriteLine($"find first user by name: {login}");
   
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null) {
                throw new UserNotFoundException("user not found");
            }
          
            var result = await _signinManager.PasswordSignInAsync(
                login.UserName, login.PasswordHash,
                login.RememberMe, false
            );

            Console.WriteLine($"singInAsyncResult: {result.Succeeded}");

            if(!result.Succeeded)
            {
                throw new LoginFailException("Verify user name or password");
            }


        }

        
       

    }
      
}
