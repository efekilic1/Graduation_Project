using System;


namespace BackgroundJobs.Abstract
{
    public interface IJobs
    {
        // DelayedJob kullarak işlem gerçekştikten belirlediğimiz süre sonrasında
        // kullanıcıya mail atılmasını veya herhangi bir işlem yapılmasını sağlayabiliyoruz.
        // FireandForget kullanıldığında ise beklemeden direkt olarak işlemi gerçekleştirir.
        void DelayedJob(int userId, string userName, TimeSpan timeSpan);
        void FireAndForget(int userId, string userName);
        void ReccuringJob();
    }
}