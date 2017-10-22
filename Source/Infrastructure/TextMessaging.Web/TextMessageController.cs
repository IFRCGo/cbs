using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.TextMessaging.Web
{
    [Route("/api/textmessages")]
    public class TextMessageController
    {
        readonly ITextMessageProcessors _textMessageProcessors;

        public TextMessageController(ITextMessageProcessors textMessageProcessors)
        {
            _textMessageProcessors = textMessageProcessors;
        }

        [HttpPost]
        public void Post([FromBody]TextMessage message)
        {
            _textMessageProcessors.Process(message);
        }
    }
}