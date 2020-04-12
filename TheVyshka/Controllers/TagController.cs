﻿using System;
using System.Threading.Tasks;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
using TheVyshka.Data.Dto;
using TheVyshka.Data.Entities;
using TheVyshka.Data.Repositories;

namespace TheVyshka.Controllers
{
    [Route("api/[controller]")]
    public class TagController: Controller
    {
        private readonly ITagRepository _repository;

        public TagController(ITagRepository repository)
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
        public async Task<IActionResult> Post([FromBody] TagDto item)
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
        [HttpPost("add/{postId}/{tagId}")]
        public async Task<IActionResult> Post(int postId, int tagId)
        {
            try
            {
                return Ok(await _repository.AddToPostAsync(postId, tagId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [Authorize]
        [HttpDelete("remove/{postId}/{tagId}")]
        public async Task<IActionResult> Delete(int postId, int tagId)
        {
            try
            {
                return Ok(await _repository.DeleteFromPostAsync(postId, tagId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TagDto item)
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