using Models.Entities;


namespace DTO.User
{
    public class CreateUserRegisterRequest
    {
        // Adminden yeni bir kullanıcı oluşturması için istediğimi propertyler.


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
