using System;
using System.Collections.Generic;
using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.UserValidation;
using Bussines.Configuration.HashHelper;
using DAL.Abstract;
using DTO.User;
using Models.Entities;

namespace Business.Concrete
{
    // Logic işlemlerimizi, validasyonlarımızı yaptığımız business katmanı

    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJobs _jobs;

        public UserService(IUserRepository userRepository, IMapper mapper, IJobs jobs)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jobs = jobs;

        }

        public CommandResponse Register(CreateUserRegisterRequest register)
        {
            //// Validation 
            var validator = new CreateUserRegisterRequestValidator();
            validator.Validate(register).ThrowIfExeption();

           
            if(_userRepository.Get(x => x.Email == register.Email) != null)
            {
                throw new Exception("This email is already registered.");
            }


            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(register.UserPassword, out passwordHash, out passwordSalt);

            var user = _mapper.Map<User>(register);

            user.Password = new UserPassword()
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _userRepository.Add(user);
            _userRepository.SaveChanges();
            _jobs.DelayedJob(user.Id, user.Name, TimeSpan.FromSeconds(15));      

            return new CommandResponse()
            {
                Message = $"The user has been successfully registered. UserId: {user.Id}, Name: {user.Name}, Surname: {user.Surname}, Email: {user.Email}",
                Status = true
            };

        }

        public IEnumerable<User> GetAll()
        {
            
            return _userRepository.GetAll();
        }

        public CommandResponse Update(UpdateUserRequest register)
        {
            //Validation

            var validator = new UpdateUserRequestValidator();
            validator.Validate(register).ThrowIfExeption();

            var user = _userRepository.Get(x => x.Id == register.Id);

            if (user == null)
            {
                throw new Exception("This email is not valid.");
            }
          
            var mappedUser = _mapper.Map(register, user);

            _userRepository.Update(mappedUser);
            _userRepository.SaveChanges();
            return new CommandResponse()
            {
                Message = $"The user has been successfully updated. Name: {mappedUser.Name}, Surname: {mappedUser.Surname}, Email: {mappedUser.Email}",
                Status = true
            };

        }

        public CommandResponse Delete(DeleteUserRequest request)
        {

            //Validation
            var validator = new DeleteUserRequestValidator();
            validator.Validate(request).ThrowIfExeption();


            if (_userRepository.Get(x => x.Id == request.Id) == null)
            {
                throw new Exception("This Id is not valid.");
            }

            var user = _userRepository.Get(x => x.Id == request.Id);
          
            _userRepository.Delete(user);
            _userRepository.SaveChanges();

            return new CommandResponse()
            {
                Message = $"The user has been successfully deleted. ",
                Status = true
            };
        }

    }
}
