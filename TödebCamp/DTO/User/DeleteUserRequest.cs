
namespace DTO.User
{
    public class DeleteUserRequest
    {
        // Databaseden bir user nesnesi silmek için kullanıcıdan sadece id almamız yeterli.
        // bu id değerini kullanarak ilgili user nesnesine ulaşabiliyor ve onu silebiliyoruz.

        public int Id { get; set; }
    }
}
