using Microsoft.Extensions.DependencyInjection;
using OmerOzkan.Digiturk.Makale.Business.Interfaces;
using OmerOzkan.Digiturk.Makale.Business.Managers;
using OmerOzkan.Digiturk.Makale.DataAccess.Interfaces;
using OmerOzkan.Digiturk.Makale.DataAccess.Repositories;

namespace OmerOzkan.Digiturk.Makale.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddSingleton(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, ArticleRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, CategoryRepository>();
           
        }
    }
}
