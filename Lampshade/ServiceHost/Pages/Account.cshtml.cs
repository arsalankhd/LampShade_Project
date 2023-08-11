using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }
        [TempData]
        public string RegisterMessage { get; set; }

        [BindProperty]
        public RegisterAccount RegisterCommand { get; set; }
        [BindProperty]
        public Login LoginCommand { get; set; }

        private readonly IAccountApplication _accountApplication;

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet(bool loginIsSuccess = true, bool registerIsIsSuccess = true)
        {
            if (!loginIsSuccess)
                LoginMessage = ApplicationMessages.WrongUserPass;

            if (!registerIsIsSuccess)
                RegisterMessage = ApplicationMessages.DuplicatedUser;
        }

        public IActionResult OnPostLogin()
        {
            var result = _accountApplication.Login(LoginCommand);
            if (result.IsSucceeded)
                return RedirectToPage("/Index");

            return RedirectToPage("/Account", new { LoginIsSuccess = false });
        }

        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostRegister()
        {
            var result = _accountApplication.Register(RegisterCommand);
            if (result.IsSucceeded)
                return RedirectToPage("/Account");

            return RedirectToPage("/Account", new { RegisterIsIsSuccess = false });
        }
    }
}