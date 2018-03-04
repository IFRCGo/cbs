using Concepts;

namespace Domain.StaffUser
{

    public interface IRequireSex 
    {
        //Making this a nullable, even though it is required as it is an Enum.  If it's not provided, we don't want the 
        //serializer defaulting to the first one
        Sex? Sex { get; }
    }
}