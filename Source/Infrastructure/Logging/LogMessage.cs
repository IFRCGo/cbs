using System;

namespace Logging
{
    public class LogMessage
    {
        public DateTimeOffset Timestamp {  get; set; }
        public string Source {  get; set; }
        public Guid CorrelationId { get; set; }
        public string Level {  get; set; }
        public string Message { get; set; }
        public string Method { get; set; }
        public int Line { get; set; }
        public object Content {  get; set; }
    }
}