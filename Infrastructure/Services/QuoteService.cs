using Dapper;
using Domain.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class QuoteService
    {
        private DapperContext _context;

        public QuoteService()
        {
            _context = new DapperContext();
        }

        public List<QuoteDto> GetQuotes()
        {
            using (var conn = _context.CreateConnetion())
            {
                var sql = $"select id as Id, author as Author, quote_text as QuoteText, category_id as CategoryId from quotes ";
                var resul = conn.Query<QuoteDto>(sql);
                return resul.ToList();

            }
        }
        public QuoteDto GetById(int id)
        {
            using (var conn = _context.CreateConnetion())
            {
                var sql = $"select id, author, quote_text as QuoteText, category_id as CategoryId from quotes where id = {id}";
                var result = conn.QuerySingle<QuoteDto>(sql);
                return result;
            }
        }
        public QuoteDto AddQuote(QuoteDto quote)
        {
            using (var conn =_context.CreateConnetion())
            {
                var sql = $"insert into quotes(author,quote_text,category_id)values(@Author, @QuoteText, @CategoryId)returning id";
                var result = conn.ExecuteScalar<int>(sql, quote);
                quote.Id = result;  return quote;

            }
        }
        public bool DeleteQuote(int id)
        {
            using(var conn = _context.CreateConnetion())
            {
                var sql = $"delete from quotes where id = {id}";
                var result = conn.Execute(sql);
                if (result > 0) return true; 
                else return false;
            }
        }
        public QuoteDto UpdateQoute(QuoteDto quote)
        {
            using(var conn = _context.CreateConnetion())
            {
                var sql = $"update quotes set author ='{quote.Author}', quote_text = '{quote.QuoteText}', category_id = {quote.CategoryId} where id = {quote.Id}";
                conn.Execute(sql); return quote;
               
            }
        }

    }
}
