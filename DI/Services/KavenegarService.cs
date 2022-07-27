using DI.Interfaces;

namespace DI.Services
{
    public class KavenegarService : ISmsService
    {
        public string SendSMS()
        {
            return "Your sms send from Kavenegar!";
        }
    }
}
