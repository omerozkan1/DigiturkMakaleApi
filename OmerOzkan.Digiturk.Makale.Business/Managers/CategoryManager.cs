using OmerOzkan.Digiturk.Makale.Business.Interfaces;
using OmerOzkan.Digiturk.Makale.DataAccess.Interfaces;
using OmerOzkan.Digiturk.Makale.Entities.Concrate;

namespace OmerOzkan.Digiturk.Makale.Business.Managers
{
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(IGenericDal<Category> genericDal, ICategoryDal categoryDal) : base(genericDal)
        {
            _categoryDal = categoryDal;
            _genericDal = genericDal;
        }

   
    }
}
