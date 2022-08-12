using System;
namespace DTO.Tokens
{
    public class TokenDto
    {
        // Token oluşturulduğunda bir geçerlilik süresi veriyoruz ve bu süre boyunca token aktif oluyor.
        // Süre dolduktan sonra token geçerliliğini yitiriyor ve kullanıcının tekrar login olarak yeni bir
        // alması gerekiyor.

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
