
namespace DTO.Bill
{
    public class DeleteBillRequest
    {

        // Databaseden bir bill nesnesi silmek için kullanıcıdan sadece id almamız yeterli.
        // bu id değerini kullanarak ilgili bill nesnesine ulaşabiliyor ve onu silebiliyoruz.

        public int Id { get; set; }
    }
}
