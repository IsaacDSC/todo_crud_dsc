using Microsoft.AspNetCore.Mvc;
using MeuTodo.UseCases;
using MeuTodo.DTO;

namespace MeuTodo.Controllers
{
    [ApiController]
    [Route("v1")]
    public class TodoController : ControllerBase
    {

        [HttpGet]
        [Route("todos")]
        public async Task<IActionResult> GetAsync()
        {
            var service = new TodoService();
            var todos = await service.FindAll();
            return Ok(todos);
        }

        [HttpGet]
        [Route("todo/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var service = new TodoService();
            var todo = await service.Find(id);
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost]
        [Route("todo")]
        public async Task<IActionResult> PostAsync([FromBody] TodoDTO body)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var service = new TodoService();
            var todo = await service.Create(body);
            return todo == null ? BadRequest("{\"message\": \"Error In Create Todo\"}") : Ok(todo);
        }

        [HttpPut]
        [Route("todo/{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] TodoDTO body)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var service = new TodoService();
            var todo = await service.Update(id, body);
            return todo == null ? BadRequest("{\"message\": \"Error In Update Todo\"}") : Ok(todo);
        }

        [HttpDelete]
        [Route("todo/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

             var service = new TodoService();
            var todo = await service.Delete(id);
            return !todo ? BadRequest("{\"message\": \"Error In Update Todo\"}") : Ok();
        }


    }
}