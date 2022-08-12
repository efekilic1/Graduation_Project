using System;
using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Concrete;
using Business.Configuration.Mapper;
using DAL.Abstract;
using DTO.Apartment;
using DTO.User;
using FluentAssertions;
using Models.Entities;
using Moq;
using Xunit;

namespace Test
{
    public class ApartmentServiceTest
    {
        [Fact]

        public void ApartmentServiceCreate_Success()
        {

            //arrange

            var apartmentRepositoryMock = new Mock<IApartmentRepository>();
            apartmentRepositoryMock.Setup(x => x.Add(It.IsAny<Apartment>()));

            MapperConfiguration mapperConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new MapperProfile());
                });

            IMapper mapper = new Mapper(mapperConfig);

            var apartmentService = new ApartmentService(apartmentRepositoryMock.Object, mapper);

            var apartmentRequest = new CreateApartmentRequest()
            {
                UserId = 1002,
                ApartmentNo = 5,
                BlockNo = 1,
                Full = true,
                HomeOwner = true,
                HouseType = "2+1"
            };

            //act

            var response = apartmentService.Create(apartmentRequest);

            response.Status.Should().BeTrue();



        }

    }
}
