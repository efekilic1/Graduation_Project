
namespace DTO.Apartment
{
    public class UpdateApartmentRequest
    {
        // Bir apartment nesnesini güncellemek için ilgili nesneye ulaşmamız gerekiyor.
        // Bu yüzden kullanıcıdan güncellemek istediği apartmentın id sini de istiyoruz.
        // Eğer bazı propertyler üzerinde güncelleme yapılamamasını istiyorsak
        // buna yönelik düzenleme yapabiliriz ve Dto dan bu propertyleri çıkarabiliriz.

        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlockNo { get; set; }
        public string HouseType { get; set; }
        public int ApartmentNo { get; set; }
        public bool Full { get; set; }
        public bool HomeOwner { get; set; }
    }
}
