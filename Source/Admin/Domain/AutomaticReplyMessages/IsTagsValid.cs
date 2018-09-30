using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AutomaticReplyMessages
{
    public delegate bool IsTagsValid(IEnumerable<string> tags);
}
