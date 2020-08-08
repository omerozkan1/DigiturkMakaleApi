using AutoMapper;
using OmerOzkan.Digiturk.Makale.Business.DTOs.ArticleDtos;
using OmerOzkan.Digiturk.Makale.Business.DTOs.CategoryDtos;
using OmerOzkan.Digiturk.Makale.Entities.Concrate;

namespace OmerOzkan.Digiturk.Makale.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ArticleAddDto, Article>();
            CreateMap<Article, ArticleAddDto>();

            CreateMap<ArticleListDto, Article>();
            CreateMap<Article, ArticleListDto>();

            CreateMap<ArticleUpdateDto, Article>();
            CreateMap<Article, ArticleUpdateDto>();
            
            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
