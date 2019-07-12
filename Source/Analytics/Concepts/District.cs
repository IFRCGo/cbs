using Dolittle.Concepts;

namespace Concepts
{
    public class District : ConceptAs<string>
    {
        public static implicit operator District(string value)
        {
            return new District {Value = value};
        }
    }
}
