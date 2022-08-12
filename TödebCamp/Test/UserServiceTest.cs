using System;
using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Concrete;
using Business.Configuration.Mapper;
using DAL.Abstract;
using DTO.User;
using FluentAssertions;
using Models.Entities;
using Moq;
using Xunit;

namespace Test
{
    public class UserServiceTest
    {
        [Fact]

        public void UserServiceCreate_Success()
        {
            //arrange

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(x => x.Add(It.IsAny<User>()));

            var jobsMock = new Mock<IJobs>();
            jobsMock.Setup(x => x.DelayedJob(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<TimeSpan>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new MapperProfile());
                });

            IMapper mapper = new Mapper(mapperConfig);

            var userService = new UserService(userRepositoryMock.Object, mapper, jobsMock.Object);

            var userRequest = new CreateUserRegisterRequest()
            {
                Name = "Ebru",
                Surname = "Egeli",
                TcNo = "1102226654",
                Email = "ebru@mail.com",
                PhoneNumber = "5057124532",
                CarPlate = "34EE1970",
                UserPassword = "1234",
                ConfirmPassword = "1234",
                Role = UserRole.User
            };

            //act

            var response = userService.Register(userRequest);

            response.Status.Should().BeTrue();


        }

    }
}

