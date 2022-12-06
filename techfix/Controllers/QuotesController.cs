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
    public class QuotesController : ControllerBase
    {
        private readonly ApiDBContext _dbContext;
        public QuotesController(ApiDBContext dbContext)
        {
              _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var Quote = await _dbContext.Quote.ToListAsync();
            return Ok(Quote);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var Quote = await _dbContext.Quote.FindAsync(id);
            return Ok(Quote);
        }

        [HttpPost]
        [Route("GetQuote")]
        public async Task<IActionResult> PostAsync(Quotes Quote)
        {
           
            _dbContext.Quote.Add(Quote);
            try
            {
              await _dbContext.SaveChangesAsync();
              return Created($"/id={Quote.id}", Quote);

            }
             catch (Exception ex){
                    throw ex;
                }
            
        }

        [HttpPut]
        [Route("updateQuote/{id}")]
        public async Task<IActionResult> PutAsync(int id, Quotes Quote)
        {
            if(id != Quote.id){
                    return BadRequest();
                }
                _dbContext.Quote.Update(Quote);
                
            try
            {
              await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException){
                if(Quote == null){
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
            var Quote = await _dbContext.Quote.FindAsync(id);
            if (Quote == null)
            {
                return NotFound();
            }
            _dbContext.Quote.Remove(Quote);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        
    }
}





        