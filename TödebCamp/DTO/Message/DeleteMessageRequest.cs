
namespace DTO.Message
{
    public class DeleteMessageRequest
    {

        // Databaseden bir message nesnesi silmek için kullanıcıdan sadece id almamız yeterli.
        // bu id değerini kullanarak ilgili message nesnesine ulaşabiliyor ve onu silebiliyoruz.

        public int Id { get; set; }
       
    }
}
