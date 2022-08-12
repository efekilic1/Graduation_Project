using DAL.MongoBase;
using Models.Document;

namespace DAL.Abstract
{
    public interface IVoucherRepository : IDocumentRepository<Voucher>
    {
        
    }
}