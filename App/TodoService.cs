using MeuTodo.Data;
using MeuTodo.DTO;
using MeuTodo.Models;

namespace MeuTodo.UseCases
{
    public class TodoService
    {

        private Todo _domain;
        public TodoService()
        {
            _domain = new Todo(new AppDbContext());
        }

        public async Task<List<Todo>> FindAll()
        {
            var todos = await this._domain.FindAll();
            return todos;
        }

        public async Task<Todo> Find(int id)
        {
            this._domain.Id = id;
            var todo = await this._domain.Find();
            return todo;
        }

        public async Task<Todo> Create(TodoDTO input)
        {
            _domain.Done = !input.Done ? false : input.Done;
            _domain.Title = input.Title;
            _domain.Description = input.Description;
            _domain.Date = DateTime.Now;
            var todo = await this._domain.Create();
            return todo;
        }

        public async Task<Todo> Update(int id, TodoDTO body)
        {
            _domain.Id = id;
            _domain.Title = body.Title;
            _domain.Description = body.Description;
            var todo = await this._domain.Update();
            return todo;
        }

        public async Task<bool> Delete(int id)
        {
            _domain.Id = id;
            var isDeletedtodo = await this._domain.Delete();
            if (isDeletedtodo == null) return false;
            return true;
        }


    }
}