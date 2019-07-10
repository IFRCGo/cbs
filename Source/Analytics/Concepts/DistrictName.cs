using Dolittle.Concepts;

namespace Concepts
{
    public class DistrictName : ConceptAs<string>
    {
        public static implicit operator DistrictName(string value)
        {
            return new DistrictName {Value = value};
        }
    }
}
