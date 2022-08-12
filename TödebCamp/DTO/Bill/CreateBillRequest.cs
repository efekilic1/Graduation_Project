using Models.Entities;

namespace DTO.Bill
{
    public class CreateBillRequest
    {
        // Admin kullanıcı fatura oluşturacağında bu DTO'yu kullanıyor
        // Bill nesnesinin Id si Entity Framework tarafından otomatik oluşturuluyor

        public int UserId { get; set; }
        public BillType Type { get; set; }
        public Month Month { get; set; }
        public string Year { get; set; } 
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; } 
    }
}
