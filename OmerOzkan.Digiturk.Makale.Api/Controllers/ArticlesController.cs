using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OmerOzkan.Digiturk.Makale.Business.DTOs.ArticleDtos;
using OmerOzkan.Digiturk.Makale.Business.Interfaces;
using OmerOzkan.Digiturk.Makale.Entities.Concrate;
using OmerOzkan.Digiturk.Makale.WebApi.CustomFilters;

namespace OmerOzkan.Digiturk.Makale.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Search(string s)
        {
            return Ok(_mapper.Map<List<ArticleListDto>>(await _articleService.SearchAsync(s)));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<ArticleListDto>>(await _articleService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Article>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<ArticleListDto>(await _articleService.GetByIdAsync(id)));
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Create(ArticleAddDto articleAddDto)
        {
            await _articleService.AddAsync(_mapper.Map<Article>(articleAddDto));
            return Created("", articleAddDto);
        }

        [HttpPut("{id}")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Article>))]
        public async Task<IActionResult> Update(int id, ArticleUpdateDto articleUpdateDto)
        {
            if (id != articleUpdateDto.Id)
            {
                return BadRequest("geçersiz id");
            }

            var updatedBlog = await _articleService.GetByIdAsync(articleUpdateDto.Id);

            updatedBlog.Title = articleUpdateDto.Title;
            updatedBlog.Description = articleUpdateDto.Description;
            updatedBlog.CategoryId = articleUpdateDto.CategoryId;

            await _articleService.UpdateAsync(updatedBlog);
            return NoContent();

        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Article>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _articleService.RemoveAsync(new Article { Id = id });
            return NoContent();
        }

    }
}