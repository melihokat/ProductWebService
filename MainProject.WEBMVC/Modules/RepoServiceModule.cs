using Autofac;
using MainProjectCORE.Repositories.Abstract;
using MainProjectCORE.Services;
using MainProjectCORE.UnitOfWorks;
using MainProjectRepository_DAL_;
using MainProjectRepository_DAL_.Repositories;
using MainProjectRepository_DAL_.UnitOfWork;
using MainProjectService.Mapping;
using MainProjectService.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace MainProject.WEBMVC.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //builder.RegisterType<ProductServiceWithNoCaching>().As<IProductService>(); webde kaldırırız.
            //Iproduckservice görünce ProduckServiceWithNoCachingi çağır.



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            //interfaceleri son ekinden yakalayabiliriz.

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //classlardan Repository ile bitenleri al o classalara karşı gelen interfaceleri al.

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith
            ("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
