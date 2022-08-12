namespace DTO.Apartment
{
    public class CreateApartmentRequest
    {
        // DTO'lar direkt olarak database'e erişmeden araya bir katman koymamızı sağlıyor.
        // DTO'lar sayesinde entitylerimizde dolaylı ve güvenli bir şekilde değişiklik yapıyoruz.
        // DTO'lar sayesinde kullanıcının görmesini istemediğimiz entity özelliklerini gizleyebiliyoruz.
        // Örneğin Apartment entitysindeki Id propertisini Entity Framework bizim yerimize otomatik olarak oluşturuyor.
        // Bir apartment nesnesi oluşturmak için kullanıcıdan id değeri istememize gerek yok.


        public int UserId { get; set; }
        public int BlockNo { get; set; }
        public string HouseType { get; set; }
        public int ApartmentNo { get; set; }
        public bool Full { get; set; }
        public bool HomeOwner { get; set; }
    }
}
