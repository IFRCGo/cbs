using System;
using Dolittle.Machine.Specifications.Events;
using Events.DataOwners;
using Events.Reports;
using Machine.Specifications;
namespace Policies.Specs.for_AlertRules
{
    public class when_something_happens : given.an_aggregate
    {
        static readonly string name = "Name";
        static readonly string email = "Email";
        Because of = () => event_source.RegisterDataOwner(name, email);

        It should_have_events = () => event_source.ShouldHaveEvent<DataOwnerRegistered>();

        It should_have_one_event = () => event_source.ShouldHaveEventCountOf(1);
        It should_have_event_with_correct_data = () => event_source.ShouldHaveEvent<DataOwnerRegistered>()
            .InStream()
            .WithValues(_ => _.Id == event_source_id, _ => _.Name == name, _ => _.Email == email);
        It should_not_have_an_event_it_doesnt_have = () => event_source.ShouldNotHaveEvent<ReportRegistered>();

    }
}