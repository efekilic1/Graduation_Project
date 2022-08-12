
namespace BackgroundJobs.Abstract
{
    public interface ISendMailService
    {
        void SendMail(int userId, string name);
    }
}