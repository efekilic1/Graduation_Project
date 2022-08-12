using System;
using BackgroundJobs.Abstract;

namespace BackgroundJobs.Concrete
{
    public class SendMailService : ISendMailService
    {
        public void SendMail(int userId, string name)
        {
            //mail atıldığını varsayıyoruz
            Console.WriteLine($"{userId} li {name} isimli kişiye mail atıldı");
        }
    }
}