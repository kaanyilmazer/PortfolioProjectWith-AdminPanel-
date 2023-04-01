using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject_Api.DAL.ApiContext;
using PortfolioProject_Api.DAL.Entity;

namespace PortfolioProject_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult CategoryById(int id) {
        using var c = new Context();
        var values = c.Categories.Find(id);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context(); 
            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }

        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var v = c.Categories.Find(id);
            if (v == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(v);
                c.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult CategoryUpdate(Category p)
        {
            using var c = new Context();
            var v = c.Find<Category>(p.CategoryID);
            if (v == null)
            {
                return NotFound();
            }
            else
            {
                v.CategoryName = p.CategoryName;
                c.Update(v);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
