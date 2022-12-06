using System.Reflection;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using techfix.Models;
using techfix.Data;
namespace techfix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriberController : ControllerBase
    {

        private readonly ApiDBContext _dbContext;
        public SubscriberController(ApiDBContext dbContext)
        {
              _dbContext = dbContext;
        }
       
          
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var Subscribers = await _dbContext.Subscriber.ToListAsync();
            return Ok(Subscribers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var Subscribers = await _dbContext.Subscriber.FindAsync(id);
            return Ok(Subscribers);
        }

        [HttpPost]
        [Route("joinNow")]
        public async Task<IActionResult> PostAsync(Subscribers subscriber)
        {
           
            _dbContext.Subscriber.Add(subscriber);
            try
            {
              await _dbContext.SaveChangesAsync();
              return Created($"/id={subscriber.id}", subscriber);

            }
             catch (Exception ex){
                    throw ex;
                }
            
        }

        [HttpPut]
        [Route("updateSubscriber/{id}")]
        public async Task<IActionResult> PutAsync(int id, Subscribers subscriber)
        {
            if(id != subscriber.id){
                    return BadRequest();
                }
                _dbContext.Subscriber.Update(subscriber);
                
              //  _dbContext.Entry(subscriber).state = EntityState.Modified;
            try
            {
              await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){
                if(subscriber == null){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return NoContent();
           
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var subscriber = await _dbContext.Subscriber.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            _dbContext.Subscriber.Remove(subscriber);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}