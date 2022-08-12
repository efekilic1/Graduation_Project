
namespace DTO.Message
{
    public class CreateMessageRequest
    {
        // Apartman sakini kullanıcılar yöneticiye mesaj yazmak istediğinde bu dto yu kullanıyorlar.
        // Bu dto ile message nesnesi oluşturuyoruz.
        // Kullanıcının sadece mesaj yazması yeterli, geri kalan propertyleri arka planda
        // otomatik olarak alıyoruz.

        public string MessageText { get; set; }
       
       
    }
}
