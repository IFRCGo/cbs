using Autofac;
using Domain.DataCollector;
using Domain.DataCollector.PhoneNumber;
using Rules.DataCollector.PhoneNumber;

namespace Rules.DataCollector
{
    public class DataCollectorRulesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataCollectorRules>().As<IDataCollectorRules>();
            builder.RegisterType<PhoneNumberRules>().As<IPhoneNumberRules>();
        }
    }
}