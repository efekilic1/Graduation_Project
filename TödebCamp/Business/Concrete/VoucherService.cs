using System;
using System.Collections.Generic;
using AutoMapper;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.VouncherValidation;
using Bussines.Abstract;
using DAL.Abstract;
using DTO.Voucher;
using FluentValidation;
using Models.Document;
using MongoDB.Bson;

namespace Bussines.Concrete
{
    // Logic işlemlerimizi, validasyonlarımızı yaptığımız business katmanı

    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _repository;
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;


        public VoucherService(IVoucherRepository repository, IMapper mapper,
            IBillRepository billRepository)
        {
           
            _billRepository = billRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public Voucher Get(ObjectId Id)
        {
            return _repository.Get(x => x.Id == Id);
        }

        public IEnumerable<Voucher> GetAll()
        {
            return _repository.GetAll();
        }



        public CommandResponse Create(CreateVoucherRequest request)
        {
            var validator = new CreateVouncherRequestValidator();
            validator.ValidateAndThrow(request);

            var vc = _billRepository.Get(x => x.Id == request.BillId);
            if (vc.Amount != request.Amount)
            {
                throw new Exception("Please enter amount correctly"); 
            }
            

            var voucher = _mapper.Map<Voucher>(request);
            var bill = _billRepository.Get(x => x.Id == voucher.BillId);
            
            bill.IsPaid = true;

            voucher.UserId = bill.UserId;
            
            _repository.Add(voucher);

            _billRepository.Update(bill);
            _billRepository.SaveChanges();

            return new CommandResponse()
            {
                
                Message = $"Voucher added. Bill Type : {bill.Type}, Month: {bill.Month}, Year: {bill.Year}",
                Status = true
            };

        }
    }
}