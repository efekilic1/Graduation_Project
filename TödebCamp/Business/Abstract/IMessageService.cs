using System.Collections.Generic;
using Business.Configuration.Response;
using DTO.Message;
using Models.Entities;

namespace Business.Abstract
{
    public interface IMessageService
    {
        CommandResponse Create(CreateMessageRequest request, int userId, string email);
        CommandResponse CreateNotice(CreateMessageRequest request, int userId, string email);
        CommandResponse Delete(DeleteMessageRequest request);

        IEnumerable<Message> GetAll();
        IEnumerable<Message> Get(int userId);
        IEnumerable<Message> GetNotices();

    }
}
