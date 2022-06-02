
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




        public async Task<User> Login(RegisterLoginViewModel login)
        {

            Console.WriteLine($"find first user by name: {login}");



            var user = await _userManager.FindByNameAsync(login.EmailAddress);
            if (user == null)
            {
                throw new UserNotFoundException("user not found");
            }


            var result =  await _signinManager.CheckPasswordSignInAsync(user,
                login.Password,
                false
            );

            Console.WriteLine($"singInAsyncResult: {result.Succeeded}");

            if (!result.Succeeded)
            {
                throw new LoginFailException("Verify user name or password");
            }

            //refresh to get last login info
            user = await _userManager.FindByNameAsync(login.EmailAddress);

            var claims = await _userManager.GetClaimsAsync(user);

            User appUser = new User();
            appUser.UserName = user.UserName;
            appUser.Email = user.Email;
            appUser.Id = user.Id;
            appUser.IsAuthenticated = true;
            appUser.Claims = claims.ToDictionary(c => c.Type, c => c.Value);


            return appUser;

        }

        public async Task Register(RegisterLoginViewModel regUser)
        {

            Console.WriteLine($"register  user by name: {regUser.EmailAddress}");

            var user = await _userManager.FindByNameAsync(regUser.EmailAddress);
            if (user != null)
            {
                throw new UserExistException("user already exist");
            }

            IdentityUser identityUser = new IdentityUser();
            //user name same as password
            identityUser.Email = regUser.EmailAddress;
            identityUser.UserName = regUser.EmailAddress;

            var result = await _userManager.CreateAsync(identityUser, regUser.Password);

            if (!result.Succeeded) new Exception(result.Errors.FirstOrDefault()?.Description);

            // and login user
            // await Login(login);
        }


        public async Task Logout()
        {

            //await _signinManager.SignOutAsync();

        }



    }

}
