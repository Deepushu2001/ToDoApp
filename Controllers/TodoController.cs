using Microsoft.AspNetCore.Mvc;
using ToDo_App.Data;
using ToDo_App.Models;

namespace ToDo_App.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoRepository _repository;

        public TodoController(TodoRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var todos = _repository.GetAllTodos();
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _repository.AddTodoItem(todoItem);
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }

        public IActionResult Edit(int id)
        {
            var todoItem = _repository.GetTodoById(id);
            return View(todoItem);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateTodoItem(todoItem);
                return RedirectToAction("Index");
            }
            return View(todoItem);
        }

        public IActionResult Delete(int id)
        {
            var todoItem = _repository.GetTodoById(id);
            return View(todoItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteTodoItem(id);
            return RedirectToAction("Index");
        }
    }
}
