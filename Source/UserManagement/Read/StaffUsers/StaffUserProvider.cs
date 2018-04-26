using System.Collections.Generic;
using System.Linq;
using Dolittle.Queries;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{
    public abstract class StaffUserProvider<T> : IQueryProviderFor<T>
        where T : BaseUser
    {
        public abstract QueryProviderResult Execute(T query, PagingInfo paging);

        protected static QueryProviderResult MakeQueryProviderResult(T query, PagingInfo paging)
        {
            var result = new QueryProviderResult();

            if (query == null)
            {
                //Todo: Perhaps throw apropriate exception
                return result;
            }

            result.Items = new List<T> { query };

            result.TotalItems = 1;

            return result;
        }
    }

    public class BaseUserProvider : StaffUserProvider<BaseUser>
    {
        public override QueryProviderResult Execute(BaseUser query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class AdminProvider : StaffUserProvider<Admin>
    {
        public override QueryProviderResult Execute(Admin query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class DataConsumerProvider : StaffUserProvider<DataConsumer>
    {
        public override QueryProviderResult Execute(DataConsumer query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class DataCoordinatorProvider : StaffUserProvider<DataCoordinator>
    {
        public override QueryProviderResult Execute(DataCoordinator query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class DataOwnerProvider : StaffUserProvider<DataOwner>
    {
        public override QueryProviderResult Execute(DataOwner query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class DataVerifierProvider : StaffUserProvider<DataVerifier>
    {
        public override QueryProviderResult Execute(DataVerifier query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class SystemConfiguratorProvider : StaffUserProvider<SystemConfigurator>
    {
        public override QueryProviderResult Execute(SystemConfigurator query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }
}