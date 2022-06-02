namespace BlazorAppETF.Models.Account
{
    public class RegisterLoginViewModel
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool RememberMe {get;set;}
    }

}
