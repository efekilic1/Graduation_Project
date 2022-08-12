using System.Collections.Generic;
using Business.Configuration.Response;
using DTO.Apartment;
using Models.Entities;

namespace Business.Abstract
{
    // ApartmentService de kullancağımız methotların imzalarını
    // bu interface aracılığıyla saklıyoruz
    public interface IApartmentService
    {
        CommandResponse Create(CreateApartmentRequest request);
        CommandResponse Update(UpdateApartmentRequest request);
        CommandResponse Delete(DeleteApartmentRequest request);
        IEnumerable<Apartment> GetAll();
    }
}
