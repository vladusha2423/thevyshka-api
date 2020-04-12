using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheVyshka.Data.Dto;
using TheVyshka.Data.Repositories;

namespace TheVyshka.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController: Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _repository.GetByIdAsync(id));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto item)
        {
            try
            {
                return Ok(await _repository.CreateAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [Authorize]
        [HttpPost("add/{postId}/{categoryId}")]
        public async Task<IActionResult> Post(int postId, int categoryId)
        {
            try
            {
                return Ok(await _repository.AddToPostAsync(postId, categoryId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [Authorize]
        [HttpDelete("remove/{postId}/{categoryId}")]
        public async Task<IActionResult> Delete(int postId, int categoryId)
        {
            try
            {
                return Ok(await _repository.DeleteFromPostAsync(postId, categoryId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryDto item)
        {
            try
            {
                return Ok(await _repository.UpdateAsync(item));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _repository.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}