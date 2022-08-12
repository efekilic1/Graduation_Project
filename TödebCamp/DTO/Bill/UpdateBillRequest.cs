using Models.Entities;

namespace DTO.Bill
{
    public class UpdateBillRequest
    {

        // Bir bill nesnesini güncellemek için ilgili nesneye ulaşmamız gerekiyor.
        // Bu yüzden kullanıcıdan güncellemek istediği billin id sini de istiyoruz.
        // Eğer bazı propertyler üzerinde güncelleme yapılamamasını istiyorsak
        // buna yönelik düzenleme yapabiliriz ve Dto dan bu propertyleri çıkarabiliriz.

        public int Id { get; set; }
        public int UserId { get; set; }
        public BillType Type { get; set; }
        public Month Month { get; set; }
        public string Year { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
    }
}
