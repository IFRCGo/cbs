using System.Collections.Generic;

namespace Nyss.Web.Features.DataCollectors
{
    public class DataCollectorViewModel
    {
        public string FullName {get; set;}
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public string Sex { get; set; }
        public string Language { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public IEnumerable<string> PhoneNumbers {get; set;}
    
    }
}
