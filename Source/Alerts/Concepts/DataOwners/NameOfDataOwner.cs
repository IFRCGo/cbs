using Dolittle.Concepts;

namespace Concepts.DataOwners
{
    public class NameOfDataOwner : ConceptAs<string>
    {
        public static implicit operator NameOfDataOwner(string value)
        {
            return new NameOfDataOwner {Value = value};
        }
    }
}
