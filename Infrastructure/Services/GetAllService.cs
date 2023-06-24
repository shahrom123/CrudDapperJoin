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
    public class GetAllService
    {
        private DapperContext _context;

        public GetAllService()
        {
            _context = new DapperContext();
        }
        public List<CategorieswithQouteDto> GetCategoriesNumQuote()
        {
            using(var conn = _context.CreateConnetion())
            {
                var sql = $" select ca.category_name as CategoryName,  count(q.quote_text) as Count from categories as ca " +
                    $" join quotes as q on q.category_id = ca.id " +
                    $" group by ca.category_name ";
                var result = conn.Query<CategorieswithQouteDto>(sql); 
                return result.ToList();
            }
        }
        public  List<CategoryQuoteDto> GetCategoriesQuote()
        {
            using(var conn = _context.CreateConnetion())
            {
                var sql = $" select ca.category_name as CategoryName, qu.quote_text as QuoteText from categories as ca join quotes as qu on qu.category_id = ca.id";  
                var result = conn.Query<CategoryQuoteDto>(sql); return result.ToList();     
            }

        }
        
    }
}
