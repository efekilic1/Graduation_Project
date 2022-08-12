using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class EFBillRepository : EFBaseRepository<Bill, ManagementDbContext>, IBillRepository
    {
        public EFBillRepository(ManagementDbContext context) : base(context)
        {
        }
    }
}




