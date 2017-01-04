using Autofac;
using UnitOfWorkPattern.Repository;
using UnitOfWorkPattern.Model;
using System.Data.Entity;

namespace UnitOfWorkPattern.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(UnitOfWorkContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
        }
    }
}