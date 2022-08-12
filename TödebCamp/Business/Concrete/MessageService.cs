using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.MessageValidation;
using DAL.Abstract;
using DTO.Message;
using Models.Entities;


namespace Business.Concrete
{
    // Logic işlemlerimizi, validasyonlarımızı yaptığımız business katmanı

    public class MessageService : IMessageService
    {

        
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper, IUserRepository userRepository)
        {
            
            _messageRepository = messageRepository;
            _mapper = mapper;
            _userRepository = userRepository;
           
        }

        public CommandResponse Create(CreateMessageRequest request, int userId, string userEmail)
        {
            //// Validations

            var validator = new CreateMessageRequestValidator();
            validator.Validate(request).ThrowIfExeption();

            var message = _mapper.Map<Message>(request);
            //var user = _userRepository.Get(x => x.Id == userId);

            
            message.ReaderRole = UserRole.Admin;
            message.UserId = userId;
            message.Email = userEmail;
            // message.Email = user.Email;


            _messageRepository.Add(message);
            _messageRepository.SaveChanges();

            return new CommandResponse()
            {
                Message = "Your message has been successfully saved.",
                Status = true
            };
        }


        public CommandResponse CreateNotice(CreateMessageRequest request, int userId, string userEmail)
        {
            //// Validations

            var validator = new CreateMessageRequestValidator();
            validator.Validate(request).ThrowIfExeption();

            var message = _mapper.Map<Message>(request);
            


            message.ReaderRole = UserRole.User;
            message.UserId = userId;
            message.Email = userEmail;
            // message.Email = user.Email;


            _messageRepository.Add(message);
            _messageRepository.SaveChanges();

            return new CommandResponse()
            {
                Message = $"Your message has been successfully saved. readerrole {message.ReaderRole}",
                Status = true
            };
        }





        public IEnumerable<Message> GetAll()
        {
           foreach(Message message in _messageRepository.GetAll())
            {
                message.IsRead = true;
                _messageRepository.SaveChanges();
            }

            return _messageRepository.GetAll();
        }

        public IEnumerable<Message> Get(int userId)
        {

            return _messageRepository.GetAll(x => x.UserId == userId).OrderBy(x => x.Id); 
        }


        public IEnumerable<Message> GetNotices()
        {
            foreach (Message message in _messageRepository.GetAll())
            {
                message.IsRead = true;
                _messageRepository.SaveChanges();
            }

            return _messageRepository.GetAll(x => x.ReaderRole == UserRole.User).OrderBy(x => x.Id);
        }



        public CommandResponse Delete(DeleteMessageRequest request)
        {
            var validator = new DeleteMessageRequestValidator();
            validator.Validate(request).ThrowIfExeption();


            var message = _messageRepository.Get(x => x.Id == request.Id);

            if (message == null)
            {
                throw new Exception("There is no record in this id in the database.");

            }


            _messageRepository.Delete(message);
            _messageRepository.SaveChanges();

            return new CommandResponse
            {
                Status = true,
                Message = "Message Deleted."
            };

        }


    }
}


