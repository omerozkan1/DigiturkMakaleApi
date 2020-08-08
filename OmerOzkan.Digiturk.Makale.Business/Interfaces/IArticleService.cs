using OmerOzkan.Digiturk.Makale.Entities.Concrate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OmerOzkan.Digiturk.Makale.Business.Interfaces
{
    public interface IArticleService : IGenericService<Article>
    {
        Task<List<Article>> SearchAsync(string s);
    }
}
