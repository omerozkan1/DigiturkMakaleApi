namespace OmerOzkan.Digiturk.Makale.Business.DTOs.ArticleDtos
{
    public class ArticleUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
