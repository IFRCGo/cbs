using System.Collections.Generic;
using System.Linq;
using doLittle.Read;
using Read.StaffUsers.Models;

namespace Read.StaffUsers
{

    public abstract class EnumerableStaffUserProvider<T> : IQueryProviderFor<IEnumerable<T>>
       where T : BaseUser
    {
        public abstract QueryProviderResult Execute(IEnumerable<T> query, PagingInfo paging);

        protected static QueryProviderResult MakeQueryProviderResult(IEnumerable<T> query, PagingInfo paging)
        {
            var result = new QueryProviderResult();

            var dataCollectors = query.ToList();

            if (!dataCollectors.Any())
            {
                return result;
            }

            if (paging.Enabled)
            {
                var start = paging.Size * paging.Number;
                dataCollectors = dataCollectors.Skip(start).Take(paging.Size).ToList();
            }

            result.Items = dataCollectors;
            result.TotalItems = dataCollectors.Count;

            return result;
        }
    }

    public class EnumerableBaseUserProvider : EnumerableStaffUserProvider<BaseUser>
    {
        public override QueryProviderResult Execute(IEnumerable<BaseUser> query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class EnumerableAdminProvider : EnumerableStaffUserProvider<Admin>
    {
        public override QueryProviderResult Execute(IEnumerable<Admin> query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class EnumerableDataConsumerProvider : EnumerableStaffUserProvider<DataConsumer>
    {
        public override QueryProviderResult Execute(IEnumerable<DataConsumer> query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class EnumerableDataCoordinatorProvider : EnumerableStaffUserProvider<DataCoordinator>
    {
        public override QueryProviderResult Execute(IEnumerable<DataCoordinator> query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class EnumerableDataOwnerProvider : EnumerableStaffUserProvider<DataOwner>
    {
        public override QueryProviderResult Execute(IEnumerable<DataOwner> query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class EnumerableDataVerifierProvider : EnumerableStaffUserProvider<DataVerifier>
    {
        public override QueryProviderResult Execute(IEnumerable<DataVerifier> query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }

    public class EnumerableSystemConfiguratorProvider : EnumerableStaffUserProvider<SystemConfigurator>
    {
        public override QueryProviderResult Execute(IEnumerable<SystemConfigurator> query, PagingInfo paging)
        {
            return MakeQueryProviderResult(query, paging);
        }
    }
}