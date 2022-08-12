
namespace DTO.Message
{
    public class GetMessageRequest
    {
        // Kullanıcının yazdığı mesajları ve mesajının yönetici tarafından okunup okunmadığını görmesi için
        // bu dto yu kullanıyoruz ancak kullanıcıdan Email talep etmiyoruz. Kullanıcının Emailini token vasıtasıyla
        // otomatik olarak arka planda alıyoruz. Kullanıcının sadece butona basması yeterli oluyor.
        

        public string Email { get; set; }
    }
}
