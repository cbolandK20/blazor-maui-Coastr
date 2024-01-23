using Coastr.Data.Common.Impl;

namespace Coastr.Services.Common
{
    public interface IApplicationMessageService
    {
        ApplicationMessage CreateMessage(ApplicationMessageCode code, ApplicationMessageType type);
        ApplicationMessage CreateMessage(Exception exception);
        ApplicationMessage CreateMessage(object payload);
    }
}