using AutoMapper;
using Business.Configuration.Auth;
using DTO.Apartment;
using DTO.Bill;
using DTO.Message;
using DTO.Tokens;
using DTO.User;
using DTO.Voucher;
using Models.Document;
using Models.Entities;

namespace Business.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //DTOlarımızı entitylere automapper yardımıyla çeviriyoruz.
            // Mapleme işleminin nasıl yapılacağını bu kısımda belirtiyoruz.
            // Hangi DTO'nun hangi entitye dönüştürüleceğini belirtiyoruz.

            CreateMap<CreateUserRegisterRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<CreateApartmentRequest, Apartment>();
            CreateMap<UpdateApartmentRequest, Apartment>();
            CreateMap<DeleteApartmentRequest, Apartment>();
            CreateMap<CreateVoucherRequest, Voucher>();
            CreateMap<CreateBillRequest, Bill>();
            CreateMap<UpdateBillRequest, Bill>();
            CreateMap<CreateMessageRequest, Message>();
            CreateMap<AccessToken, TokenDto>();
        }
    }
}
