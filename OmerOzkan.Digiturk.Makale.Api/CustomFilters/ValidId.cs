using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OmerOzkan.Digiturk.Makale.Business.Interfaces;
using System.Linq;

namespace OmerOzkan.Digiturk.Makale.WebApi.CustomFilters
{
    public class ValidId<T> : IActionFilter where T : class, new()
    {
        private readonly IGenericService<T> _genericService;
        public ValidId(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(I => I.Key == "id").FirstOrDefault();

            var id = int.Parse(dictionary.Value.ToString());

            var entity = _genericService.GetByIdAsync(id).Result;
            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"{id} degerine sahip nesne bulunamadı");
            }
        }
    }
}
