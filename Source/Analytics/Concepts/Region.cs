using Dolittle.Concepts;

namespace Concepts
{
    public class Region : ConceptAs<string>
    {
        public static implicit operator Region(string value)
        {
            return new Region {Value = value};
        }
    }
}
