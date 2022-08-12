
namespace DTO.Voucher
{
    public class CreateVoucherRequest
    {
        // ödeme servisinde kullandığımız Voucher nesnesini oluşturduğumuz dto
       
        public int BillId { get; set; }
        public decimal Amount { get; set; }
        public string CreditCardNumber { get; set; }
        public string Cvc { get; set; }
       


    }
}
