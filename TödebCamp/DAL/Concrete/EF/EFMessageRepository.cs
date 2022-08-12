using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class EFMessageRepository : EFBaseRepository<Message, ManagementDbContext>, IMessageRepository
    {
        public EFMessageRepository(ManagementDbContext context) : base(context)
        {
        }
    }
}
