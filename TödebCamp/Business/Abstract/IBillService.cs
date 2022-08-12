using System.Collections.Generic;
using Business.Configuration.Response;
using DTO.Bill;
using Models.Entities;

namespace Business.Abstract
{
    // BillService de kullancağımız methotların imzalarını
    // bu interface aracılığıyla saklıyoruz
    public interface IBillService
    {
        CommandResponse Create(CreateBillRequest request);
        CommandResponse Update(UpdateBillRequest request);
        CommandResponse Delete(DeleteBillRequest request);
        IEnumerable<Bill> GetAll();
        IEnumerable<Bill> Get();

        

    }
}


