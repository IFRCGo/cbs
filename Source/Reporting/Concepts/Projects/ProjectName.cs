using Dolittle.Concepts;

namespace Concepts.Projects
{
    public class ProjectName : ConceptAs<string>
    {
        public static implicit operator ProjectName(string value)
        {
            return new ProjectName { Value = value };
        }
    }
}