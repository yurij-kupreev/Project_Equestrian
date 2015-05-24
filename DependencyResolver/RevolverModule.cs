using System.Data.Entity;
using BLL.Interface;
using BLL.Interface.Services;
using BLL.Services;
using DAL.Concrete;
using DAL.Interface.Repository;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();
            kernel.Bind<IResultRepository>().To<ResultRepository>();
            kernel.Bind<IAthleteRepository>().To<AthleteRepository>();
            kernel.Bind<ICompetitionRepository>().To<CompetitionRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IResultService>().To<ResultService>();
            kernel.Bind<IAthleteService>().To<AthleteService>();
            kernel.Bind<ICompetitionService>().To<CompetitionService>();
            kernel.Bind<IAccountService>().To<AccountService>();
        }
    }
}