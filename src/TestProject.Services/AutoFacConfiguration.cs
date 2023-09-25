using Autofac;
using TestProject.Core.Interfaces;
using TestProject.DTO.Common;
using TestProject.Repositories.Account.User;
using TestProject.Repositories.UOW;
using TestProject.Services.Account.User;


namespace TestProject.Services;

public class AutoFacConfiguration : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        // Register unit of work
        builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerDependency();
        //// Register DTO
        builder.RegisterType<ResponseDTO>().As<IResponseDTO>().InstancePerLifetimeScope();
        builder.RegisterType<InvetoryRequestResponseDTO>().As<IInvetoryRequestResponseDTO>().InstancePerLifetimeScope();
        builder.RegisterType<StockQuantityResponseDTO>().As<IStockQuantityResponseDTO>().InstancePerLifetimeScope();
        // Register general services
        builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

    }
}

