using System.Collections.Generic;
using System.Linq;

namespace Nyss.Web.Features.SmsGateway.Logic.Models
{
    public class ValidationResult
    {
        public bool IsValid => !Errors.Any();
        public List<string> Errors { get; set; }

        public ValidationResult()
        {
            Errors = new List<string>();
        }
    }
}
