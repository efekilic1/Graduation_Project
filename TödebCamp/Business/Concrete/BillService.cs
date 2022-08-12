using System.Collections.Generic;
using AutoMapper;
using Business.Abstract;
using Business.Configuration.Response;
using DAL.Abstract;
using DTO.Bill;
using Models.Entities;
using System.Linq;
using Business.Configuration.Validator.FluentValidation.BillValidation;
using Business.Configuration.Extensions;
using Microsoft.AspNetCore.Http;
using System;

namespace Business.Concrete
{
    // Logic işlemlerimizi, validasyonlarımızı yaptığımız business katmanı

    public class BillService : IBillService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBillRepository _billRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public BillService(IBillRepository billRepository, IMapper mapper, IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _billRepository = billRepository;
            _mapper = mapper;
            
        }
  
        public CommandResponse Create(CreateBillRequest request)
        {
            //// Validations

            var billCheck = _billRepository.Get(x => x.Year == request.Year && x.Month == request.Month);

            if (billCheck != null)
            {
                throw new Exception("There is already an invoice for this date.");
            }


            var validator = new CreateBillRequestValidator();
            validator.Validate(request).ThrowIfExeption();

            var bill = _mapper.Map<Bill>(request);
            _billRepository.Add(bill);
            _billRepository.SaveChanges();



            return new CommandResponse()
            {
                Status = true,
                Message = $"Bill added. UserId: {request.UserId}, BillType: {request.Type}, Amount: {request.Amount}"
            };
        }

        public CommandResponse Update(UpdateBillRequest request)
        {
            //// Validations

            var validator = new UpdateBillRequestValidator();
            validator.Validate(request).ThrowIfExeption();

            var entity = _billRepository.Get(x => x.Id == request.Id);

            if (entity == null)
            {
                throw new Exception("There is no record in this id in the database.");

            }

            var bill = _mapper.Map(request,entity);
            _billRepository.Update(bill);
            _billRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Message = "Bill Updated."
            };
        }


        public CommandResponse Delete(DeleteBillRequest request)
        {
            //// Validations

            var validator = new DeleteBillRequestValidator();
            validator.Validate(request).ThrowIfExeption();


            var bill = _billRepository.Get(x => x.Id == request.Id);

            if (bill == null)
            {
                throw new Exception("There is no record in this id in the database.");

            }


            _billRepository.Delete(bill);
            _billRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Message = $"Bill Deleted. BillId :{bill.Id}, Type : {bill.Type}"
            };


        }




        public IEnumerable<Bill> GetAll()
        {
            return _billRepository.GetAll();
        }

        public IEnumerable<Bill>  Get()
        {
            int userID = int.Parse(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value);

            return _billRepository.GetAll(x => x.UserId == userID).Where(x => x.IsPaid == false);

        }





    }
    
}




