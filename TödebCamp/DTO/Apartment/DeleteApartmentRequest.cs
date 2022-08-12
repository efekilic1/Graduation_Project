
namespace DTO.Apartment
{
    public class DeleteApartmentRequest
    {

        // Databaseden bir apartment nesnesi silmek için kullanıcıdan sadece id almamız yeterli.
        // bu id değerini kullanarak ilgili apartment nesnesine ulaşabiliyor ve onu silebiliyoruz.

        public int Id { get; set; }
        
    }
}
