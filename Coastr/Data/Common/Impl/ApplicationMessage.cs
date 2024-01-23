namespace Coastr.Data.Common.Impl
{
    public class ApplicationMessage
    {
        public ApplicationMessageType Type { get; set; }
        public object Payload { get; set; }
        public string Text { get; set; }
        public int Code { get; set; }

        public Exception Error { get; set; }

        public ApplicationMessage()
        {

        }
    }

    public enum ApplicationMessageType
    {
        CRITICAL,
        ERROR,
        WARNING,
        INFO,
        SUCCESS,
        VALUE
    }
}
