using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class QuoteController
    {
        private QuoteService _quoteservice;

        public QuoteController()
        {
            _quoteservice= new QuoteService();
        }

        [HttpGet("GetQuote")]
        public List<QuoteDto> GetQuote()
        {
            return _quoteservice.GetQuotes(); 
        }

        [HttpGet("GetCategoryById")]
        public QuoteDto GetCategoryById(int id)
        {
            return _quoteservice.GetById(id);
        }

        [HttpPost("AddQoute")]
        public QuoteDto AddQuote (QuoteDto quote)
        {
            return _quoteservice.AddQuote(quote); 
        }

        [HttpDelete("DeleteQoote")]
        public bool DeleteQuote(int id)
        {
           return _quoteservice.DeleteQuote(id); 
        }

        [HttpPut("UpdateQuote")]
        public QuoteDto UpdateQote(QuoteDto quote)
        {
            return _quoteservice.UpdateQoute(quote);
        }

 
    }
}
