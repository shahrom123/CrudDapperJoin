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
    public class CategoryService
    {
        private DapperContext _context;

        public CategoryService()
        {
            _context = new DapperContext();
        }
        public List<CategoryDto> GetCategories()
        {
            using(var conn =_context.CreateConnetion())
            {
                var sql = $"select id as Id, category_name as CategoryName from categories";
                var result =conn.Query<CategoryDto>(sql) ; return result.ToList() ;  
            }
        }

        public CategoryDto GetById(int id)
        {
            using (var conn = _context.CreateConnetion())
            {
                var sql = $"select id, category_name as CategoryName from categories where id = {id}";
                var result = conn.QuerySingle<CategoryDto>(sql);
                return result;
            }
        }

        public CategoryDto AddCategory(CategoryDto category)
        {
            using(var conn = _context.CreateConnetion())
            {
                var sql = $"insert into categories(category_name)values(@CategoryName) returning id";
                var result = conn.ExecuteScalar<int>(sql, category);
                category.Id = result;  return category; 
            }   
        }

        public bool DeleteCategory(int id)
        {
            using(var conn =_context.CreateConnetion())
            {
                var sql = $"delete from categories where id = {id}";
                var result = conn.Execute(sql) ;
                if (result > 0) return true; 
                return false ;
            }
        }

        public CategoryDto UpdateCategory(CategoryDto category)
        {
            using(var conn = _context.CreateConnetion())
            {
                var sql = $"update categories set " +
                    $"category_name ='{category.CategoryName}' " +
                    $"where id ={category.Id}";
                    conn.Execute(sql) ; return category;  
            }
        }

    }
}
