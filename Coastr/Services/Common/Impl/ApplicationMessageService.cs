using Coastr.Data.Common.Impl;

namespace Coastr.Services.Common.Impl
{
    public class ApplicationMessageService : IApplicationMessageService
    {
        public ApplicationMessage CreateMessage(ApplicationMessageCode code, ApplicationMessageType type)
        {
            var text = AppMessages.ResourceManager.GetString(code.ToString());
            return new ApplicationMessage() { Type = type, Text = text };
        }

        public ApplicationMessage CreateMessage(Exception exception)
        {
            return new ApplicationMessage() { Error = exception, Type = ApplicationMessageType.CRITICAL };
        }

        public ApplicationMessage CreateMessage(object payload)
        {
            return new ApplicationMessage()
            {
                Payload = payload,
                Type = ApplicationMessageType.SUCCESS
            };
        }
    }
}
