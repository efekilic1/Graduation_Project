using DAL.Abstract;
using DAL.MongoBase;
using Microsoft.Extensions.Configuration;
using Models.Document;
using MongoDB.Driver;

namespace DAL.Concrete.Mongo
{
    // Ödeme tarafında kullandığımız Mongo DB bağlantılı repositorymiz

    public class VoucherRepository : DocumentRepository<Voucher>, IVoucherRepository
    {
        private const string CollectionName = "Voucher";

        public VoucherRepository(MongoClient client, IConfiguration configuration) : base(client, configuration, CollectionName)
        {

        }
    }
}