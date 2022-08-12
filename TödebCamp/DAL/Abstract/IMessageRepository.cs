using System;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Abstract
{
    public interface IMessageRepository : IEFBaseRepository<Message>
    {
        
    }
}
