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

        [HttpGet("{page}-{count}")]
        public async Task<IActionResult> Get(int page, int count)
        {
            try
            {
                return Ok(await _repository.GetAllAsync(page, count));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(Guid id)
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
        
        [HttpGet("rubric/{rubric}/{page}-{count}")]
        public async Task<IActionResult> GetByRubric(string rubric, int page, int count)
        {
            try
            {
                return Ok(await _repository.GetByRubricAsync(rubric, page, count));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("collab/{collaboratorName}/{page}-{count}")]
        public async Task<IActionResult> GetByCollaborator(string collaboratorName, int page, int count)
        {
            try
            {
                return Ok(await _repository.GetByCollaboratorAsync(collaboratorName, page, count));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet("tag/{tagName}/{page}-{count}")]
        public async Task<IActionResult> GetByTag(string tagName, int page, int count)
        {
            try
            {
                return Ok(await _repository.GetByTagAsync(tagName, page, count));
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
        public async Task<IActionResult> Delete(Guid id)
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