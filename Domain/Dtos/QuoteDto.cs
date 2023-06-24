using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class QuoteDto
    {
        public int Id { get; set;}  
        public string Author { get; set;}  
        public string QuoteText { get; set;}   
        public int CategoryId { get; set;}
       
    }
}
