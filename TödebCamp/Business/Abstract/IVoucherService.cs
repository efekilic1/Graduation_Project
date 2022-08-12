using Business.Configuration.Response;
using DTO.Voucher;


namespace Bussines.Abstract
{
    public interface IVoucherService
    {
        CommandResponse Create(CreateVoucherRequest request);
    }
}