using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Controllers;
using ToDoAPI.Models;

namespace ToDoAPI.Tests
{
    public class TodoControllerTests
    {
        // Testing AddToDoItem function of TodoController returns Success
        [Fact]
        public void AddTodoItem_Returns_Success()
        {
            // Arrange
            var controller = new TodoItemsController();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            var description = "Task 4";
            TodoItem newItem = new TodoItem()
            {
                Description = description,
                CreateDate = DateTime.Now
            };

            // Act
            var actionResult = controller.AddTodoItem(newItem);

            // Assert
            var okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal($"{description} has been added successfully", okResult.Value);
        }

        // Testing GetToDoItems function of TodoController returns Correct Count of List items
        [Fact]
        public void GetTodoItems_Returns_Correct_Number_of_Items()
        {
            // Arrange
            int totalItems = 3;
            var controller = new TodoItemsController();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var actionResult = controller.GetTodoItems();

            // Assert
            var okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);
            var _todoItems = okResult.Value as List<TodoItem>;
            Assert.Equal(totalItems,_todoItems.Count);
        }

        // Testing DeleteToDoItem function of TodoController returns Success
        [Fact]
        public void DeleteTodoItem_Returns_Success()
        {
            // Arrange
            var controller = new TodoItemsController();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            int id = 1; // Assuming the first item is deleted

            // Act
            var getTodoItemsResult = controller.GetTodoItems();
            var okResult = getTodoItemsResult as ObjectResult;
            var todoItems = okResult.Value as List<TodoItem>;

            // Find the todo item with id 1
            var todoItemToDelete = todoItems.FirstOrDefault(item => item.Id == id);
            Assert.NotNull(todoItemToDelete); // Ensure the item with id 1 exists before deletion
            string description = todoItemToDelete.Description;

            var actionResult = controller.DeleteTodoItem(id);

            // Assert
            var deletionResult = actionResult as OkObjectResult;
            Assert.NotNull(deletionResult);
            Assert.Equal(description + " has been deleted successfully", deletionResult.Value);
        }

    }
}
