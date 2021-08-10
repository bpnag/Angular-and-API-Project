using System.Web.Http;
using TechnicalExercise.Repos.Triangle;
using TechnicalExercise.Services.BlockCoordinates;
using TechnicalExercise.Services.TriangleCoordinates;
using Unity;
using Unity.WebApi;

namespace TechnicalExercise
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ITriangle, TriangleRepository>();
            container.RegisterType<IBlockCoordinates, BlockCoordinates>();
            container.RegisterType<ITriangleCoordinates, TriangleCoordinates>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}