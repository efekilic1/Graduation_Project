using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class EFApartmentRepository : EFBaseRepository<Apartment, ManagementDbContext>, IApartmentRepository
    {

        public EFApartmentRepository(ManagementDbContext context) :base(context)
        {

        }
    }
}
