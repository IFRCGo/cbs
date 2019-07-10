using Dolittle.Concepts;

namespace Concepts
{
    public class VillageName : ConceptAs<string>
    {
        public static implicit operator VillageName(string value)
        {
            return new VillageName {Value = value};
        }
    }
}
