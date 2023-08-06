namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void SignIn(AuthViewModel account);
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
    }
}
