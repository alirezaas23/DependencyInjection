using DI.Interfaces;

namespace DI.Services
{
    public class ParsGreenService : ISmsService
    {
        public string SendSMS()
        {
            return "Your sms send from ParsGreen!";
        }
    }
}
