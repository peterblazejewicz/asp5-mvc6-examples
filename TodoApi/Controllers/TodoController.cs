using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {

        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }
        // GET: /api/todo
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _repository.AllItems;
        }

        // GET api/todo/id
        [HttpGet("{id:int}", Name = "GetByIdRoute")]
        public IActionResult GetById(int id)
        {
            var item = _repository.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(item);
        }

        // POST api/todo
        [HttpPost]
        public void CreateTodoItem([FromBody] TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                _repository.Add(item);

                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id }, Request.Scheme, Request.Host.ToUriComponent());
                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
            }
        }

        // DELETE api/todo/id
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (_repository.TryDelete(id) == true)
            {
                return new HttpStatusCodeResult(204); // 201 No Content
            }
            else
            {
                return HttpNotFound();
            }

        }

    }
}
