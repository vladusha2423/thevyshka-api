﻿using System;
using System.Threading.Tasks;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
using TheVyshka.Data.Dto;
using TheVyshka.Data.Repositories;

namespace TheVyshka.Controllers
{
    [Route("api/[controller]")]
    public class PostController: Controller
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("{selection}/{page}-{count}")]
        public async Task<IActionResult> Get(string selection, int page, int count)
        {
            try
            {
                return Ok(await _repository.GetAllAsync(selection, page, count));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("id/{id}")]
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
        
        [HttpGet("category/{catId}/{page}-{count}")]
        public async Task<IActionResult> GetByCategory(int catId, int page, int count)
        {
            try
            {
                return Ok(await _repository.GetByCategoryAsync(catId, page, count));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("collab/{collabId}/{page}-{count}")]
        public async Task<IActionResult> GetByCollaborator(int collabId, int page, int count)
        {
            try
            {
                return Ok(await _repository.GetByCollaboratorAsync(collabId, page, count));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("tag/{tagId}/{page}-{count}")]
        public async Task<IActionResult> GetByTag(int tagId, int page, int count)
        {
            try
            {
                return Ok(await _repository.GetByTagAsync(tagId, page, count));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("search/{name}/{page}-{count}")]
        public async Task<IActionResult> GetByName(string name, int page, int count)
        {
            try
            {
                return Ok(await _repository.GetByNameAsync(name, page, count));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostDto item)
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
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PostDto item)
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