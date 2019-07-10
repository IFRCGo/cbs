using Dolittle.Concepts;

namespace Concepts
{
    public class Village : ConceptAs<string>
    {
        public static implicit operator Village(string value)
        {
            return new Village {Value = value};
        }
    }
}
