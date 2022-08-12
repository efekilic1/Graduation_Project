
namespace DTO.Auth
{
    public class LoginDto
    {
        // Bu Dto ile kullanıcı girişi yapabiliyoruz.
        // Kullanıcı girişi yapmak için Email ve Şifre yeterli
        // Onun için diğer User propertylerini kullanıcıdan talep etmiyoruz.

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
