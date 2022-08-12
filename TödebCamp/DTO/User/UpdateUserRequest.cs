using Models.Entities;

namespace DTO.User
{
    public class UpdateUserRequest
    {
        // Bir user nesnesini güncellemek için ilgili nesneye ulaşmamız gerekiyor.
        // Bu yüzden kullanıcıdan güncellemek istediği userın id sini de istiyoruz.
        // Eğer bazı propertyler üzerinde güncelleme yapılamamasını istiyorsak
        // buna yönelik düzenleme yapabiliriz ve Dto dan bu propertyleri çıkarabiliriz.

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TcNo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarPlate { get; set; }
        public string UserPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public UserRole Role { get; set; }
    }
}
