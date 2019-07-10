using Dolittle.Concepts;

namespace Concepts.DataCollectors
{
    public class DataCollectorName : ConceptAs<string>
    {
        public static implicit operator DataCollectorName(string value)
        {
            return new DataCollectorName {Value = value};
        }
    }
}
