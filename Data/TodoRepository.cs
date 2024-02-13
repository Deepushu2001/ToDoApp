using ToDo_App.Models;



namespace ToDo_App.Data
{
    public class TodoRepository
    {
        private readonly TodoDbContext _dbContext;

        public TodoRepository(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TodoItem> GetAllTodos()
        {
            return _dbContext.TodoItems.ToList();
        }

        public TodoItem GetTodoById(int id)
        {
            return _dbContext.TodoItems.FirstOrDefault(t => t.Id == id);
        }

        public void AddTodoItem(TodoItem todoItem)
        {
            _dbContext.TodoItems.Add(todoItem);
            _dbContext.SaveChanges();
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            _dbContext.TodoItems.Update(todoItem);
            _dbContext.SaveChanges();
        }

        public void DeleteTodoItem(int id)
        {
            var todoItem = _dbContext.TodoItems.Find(id);
            if (todoItem != null)
            {
                _dbContext.TodoItems.Remove(todoItem);
                _dbContext.SaveChanges();
            }
        }
    }
}
