using System;
using BackgroundJobs.Abstract;

namespace BackgroundJobs.Concrete
{
    public class Jobs : IJobs
    {
        private ISendMailService _sendMailService;

        public Jobs(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        public void DelayedJob(int userId, string userName, TimeSpan timeSpan)
        {
            Hangfire.BackgroundJob.Schedule(() =>
                    _sendMailService.SendMail(userId, userName), timeSpan);
        }

        public void FireAndForget(int userId, string userName)
        {
            Hangfire.BackgroundJob.Enqueue(() => _sendMailService.SendMail(userId, userName));
        }

        public void ReccuringJob()
        {
            Console.WriteLine($"Recurring job örneği {DateTime.Now}");
        }
    }
}