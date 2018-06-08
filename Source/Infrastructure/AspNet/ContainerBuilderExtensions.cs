using Autofac;
using Infrastructure.Read.MongoDb;

namespace Infrastructure.AspNet
{
    public static class ContainerBuilderExtensions
    {
        public static void AddReadModule(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ReadModule>().As<IReadModule>().AutoActivate();
        }
    }
}