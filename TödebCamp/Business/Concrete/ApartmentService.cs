using System;
using System.Collections.Generic;
using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.ApartmentValidation;
using DAL.Abstract;
using DTO.Apartment;
using FluentValidation;
using Models.Entities;

namespace Business.Concrete
{

    // Logic işlemlerimizi, validasyonlarımızı yaptığımız business katmanı

    public class ApartmentService : IApartmentService
    {
        
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
           
        }

        public CommandResponse Create(CreateApartmentRequest request)
        {
            //// Validations
            var validator = new CreateApartmentRequestValidator();
            validator.ValidateAndThrow(request);

            var aptCheck = _apartmentRepository.Get(x => x.BlockNo == request.BlockNo && x.ApartmentNo == request.ApartmentNo);

            if (aptCheck != null)
            {
                throw new Exception("This apartment is already registered.");
            }

            var userCheck = _apartmentRepository.Get(x => x.UserId == request.UserId);

            if (userCheck != null)
            {
                throw new Exception("This user already has an apartment.");
            }


            var apartment = _mapper.Map<Apartment>(request);
            _apartmentRepository.Add(apartment);
            _apartmentRepository.SaveChanges();

            return new CommandResponse()
            {
                Status = true,
                Message = $"Apartment added. ApartmentNo : {apartment.ApartmentNo}, HouseType : {apartment.HouseType}, BlockNo : {apartment.BlockNo}, UserId : {apartment.UserId}, "
            };
        }


        public CommandResponse Update(UpdateApartmentRequest request)
        {
           //// Validations
            var validator = new UpdateApartmentRequestValidator();
            validator.Validate(request).ThrowIfExeption();

            var entity = _apartmentRepository.Get(x => x.Id == request.Id );
            if (entity == null)
            {
                throw new Exception("There is no record in this id in the database.");
            }


            var apartment = _mapper.Map(request, entity);

            _apartmentRepository.Update(apartment);
            _apartmentRepository.SaveChanges();

            return new CommandResponse()
            {
                Status = true,
                Message = $"Apartment updated. ApartmentId : {apartment.Id}, ApartmentNo : {apartment.ApartmentNo}, HouseType : {apartment.HouseType}, BlockNo : {apartment.BlockNo}, UserId : {apartment.UserId}, "
            };
        }

        public CommandResponse Delete(DeleteApartmentRequest request)
        {
            //// Validations
            var validator = new DeleteApartmentRequestValidator();
            validator.ValidateAndThrow(request);
            var apartment = _apartmentRepository.Get(x => x.Id == request.Id);

            if ( apartment == null)
            {
                throw new Exception("There is no record in this id in the database.");

            }

            
            _apartmentRepository.Delete(apartment);
            _apartmentRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Message = "Apartment deleted."
            };
        }

        public IEnumerable<Apartment> GetAll()
        {
            return _apartmentRepository.GetAll();
        }


    }
}
