using MeuTodo.Data;
using Microsoft.EntityFrameworkCore;

namespace MeuTodo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        private AppDbContext _ctx;
        
        public Todo(AppDbContext context)
        {
            _ctx = context;
        }

        public async Task<List<Todo>> FindAll()
        {
            return await this._ctx.Todos.AsNoTracking().ToListAsync();
        }

        public async Task<Todo> Find()
        {
            var todo = await this._ctx.Todos.FirstOrDefaultAsync(x => x.Id == this.Id);
            return todo ?? this;
        }

        public async Task<Todo> Create()
        {
            try
            {
                await this._ctx.Todos.AddAsync(this);
                await this._ctx.SaveChangesAsync();
                return this;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null ?? this;
            }
        }

        public async Task<Todo> Update()
        {
            try
            {
                this._ctx.Todos.Update(this);
                await this._ctx.SaveChangesAsync();
                return this;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null ?? this;
            }
        }

        public async Task<Todo> Delete()
        {
            try
            {
                this._ctx.Todos.Remove(this);
                await this._ctx.SaveChangesAsync();
                return this;
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
                return null ?? this;
            }
        }


    }
}