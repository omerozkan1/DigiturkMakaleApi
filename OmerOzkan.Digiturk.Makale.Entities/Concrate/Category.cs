using System.Collections.Generic;

namespace OmerOzkan.Digiturk.Makale.Entities.Concrate
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}
