using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        //Declaring static List with mock data to store items in memory
        private static List<TodoItem> _todoItems = new List<TodoItem>
        {
            new TodoItem { Id = 1, Description = "Task 1" },
            new TodoItem { Id = 2, Description = "Task 2" },
            new TodoItem { Id = 3, Description = "Task 3" }
        };
        /// <summary>
        /// Retrieves the list of todo items.
        /// </summary>
        /// <returns>
        /// _todoItems List with Id, description and Create Date
        /// </returns>
        [HttpGet]
        [Route("GetTodoItems")]
        public  IActionResult GetTodoItems()
        {
            return (Ok(_todoItems));
        }
        /// <summary>
        /// Adds a new todo item to the list.
        /// </summary>
        /// <param name="item">The todo item to be added with description as a required field</param>
        /// <returns>
        /// An HTTP response indicating success or failure along with the newly added todo item.
        /// </returns>
        [HttpPost]
        [Route("AddTodoItem")]
        public IActionResult AddTodoItem(TodoItem item)
        {
            var newItem = new TodoItem
            {
                Id = _todoItems.Count + 1,
                CreateDate = item.CreateDate,
                Description = item.Description
            };
            _todoItems.Add(newItem);
            return (Ok($"{item.Description} has been added successfully"));
        }
        /// <summary>
        /// Deletes a todo item from the list.
        /// </summary>
        /// <param name="id">The id of the todo item to delete.</param>
        /// <returns>
        ///     An HTTP response indicating success or failure.
        /// </returns>
        [HttpDelete]
        [Route("DeleteTodoItem")]
        public IActionResult DeleteTodoItem(int id)
        {
            var item = _todoItems.Find(todo => todo.Id == id);
            if (item != null)
            {
                _todoItems.Remove(item);
                return (Ok($"{item.Description} has been deleted successfully" ));
            }
            else
            {
                return (NotFound(new { error = "Todo item not found" }));
            }
        }
    }
}
