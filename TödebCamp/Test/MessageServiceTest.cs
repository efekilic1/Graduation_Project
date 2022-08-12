using AutoMapper;
using Business.Concrete;
using Business.Configuration.Mapper;
using DAL.Abstract;
using DTO.Message;
using DTO.User;
using FluentAssertions;
using Models.Entities;
using Moq;
using Xunit;

namespace Test
{
    public class MessageServiceTest
    {

        [Fact]
        public void MessageServiceCreate_Success()
        {
            //arrange
            var messageRepositoryMock = new Mock<IMessageRepository>();
            messageRepositoryMock.Setup(x => x.Add(It.IsAny<Message>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new MapperProfile());
                });

            IMapper mapper = new Mapper(mapperConfig);

            var userRegisterRequest = new CreateUserRegisterRequest
            {
                Name = "test",
                Surname = "test",
                PhoneNumber = "test",
                Role = UserRole.User,
                CarPlate = "---",
                Email = "test@mail.com",
                TcNo = "test",
                UserPassword = "1234",
                ConfirmPassword = "1234"
            };

            var user = mapper.Map<User>(userRegisterRequest);

            user.Id = 1;

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Add(user)).Returns(user);

         

            var messageService = new MessageService(messageRepositoryMock.Object, mapper, userRepositoryMock.Object);

            var messageRequest = new CreateMessageRequest()
            {
                MessageText = "Deneme, Test, 2022"
            };

            var message = mapper.Map<Message>(messageRequest);
            message.Email = user.Email;
            message.UserId = user.Id;

            //act 

            var response = messageService.Create(messageRequest, user.Id, user.Email);

            response.Status.Should().BeTrue();


        }


    }
}
