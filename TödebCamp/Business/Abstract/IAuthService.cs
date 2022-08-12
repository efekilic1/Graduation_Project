using Business.Configuration.Response;
using Business.Configuration.Auth;


namespace Business.Abstract
{
    // AuthService de kullancağımız methotların imzalarını
    // bu interface aracılığıyla saklıyoruz

    public interface IAuthService
    {
        CommandResponse VerifyPassword(string email, string password);
       
        AccessToken Login(string email, string password);
    }
}