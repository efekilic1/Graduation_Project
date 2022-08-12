using System.Linq;
using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class EFUserRepository : EFBaseRepository<User, ManagementDbContext>, IUserRepository
    {
       

        public EFUserRepository(ManagementDbContext context):base(context)
        {
           
        }

        public User GetById(int id)
        {
 
         return Context.Users.FirstOrDefault(x => x.Id == id);
            
        }

        public User GetUserWithPassword(string email)
        {

         return Context.Users.Include(x => x.Password).FirstOrDefault(x => x.Email == email);

            
        }

    } 
    
}





