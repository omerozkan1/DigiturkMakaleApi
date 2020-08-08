using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OmerOzkan.Digiturk.Makale.Business.DTOs.CategoryDtos;
using OmerOzkan.Digiturk.Makale.Business.Interfaces;
using OmerOzkan.Digiturk.Makale.Entities.Concrate;
using OmerOzkan.Digiturk.Makale.WebApi.CustomFilters;

namespace OmerOzkan.Digiturk.Makale.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CategoryListDto>(await _categoryService.GetByIdAsync(id)));
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("", categoryAddDto);
        }

        [HttpPut("{id}")]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Update(int id,CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.Id)
                return BadRequest("geçersiz id");
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.RemoveAsync(new Category { Id = id });
            return NoContent();
        }
    }
}