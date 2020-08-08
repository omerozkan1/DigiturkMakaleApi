using OmerOzkan.Digiturk.Makale.Business.Interfaces;
using OmerOzkan.Digiturk.Makale.DataAccess.Interfaces;
using OmerOzkan.Digiturk.Makale.Entities.Concrate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OmerOzkan.Digiturk.Makale.Business.Managers
{
    public class ArticleManager : GenericManager<Article>, IArticleService
    {
        private readonly IGenericDal<Article> _genericDal;        
        private readonly IArticleDal _articleDal;
        
        public ArticleManager(IGenericDal<Article> genericDal,IArticleDal articleDal) : base(genericDal)
        {
            _articleDal = articleDal;            
            _genericDal = genericDal;
        }

        public async Task<List<Article>> SearchAsync(string s)
        {           
            return await _articleDal.GetAllAsync(I => I.Title.Contains(s) || I.Description.Contains(s),I=> I.CategoryId);
        }      
    }
}
