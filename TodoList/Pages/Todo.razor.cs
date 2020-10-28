using System.Collections.Generic;
using TodoList.Shared;
using System;
namespace TodoList.Pages
{
    public partial class Todo {
        private IList<TodoItem> todos = new List<TodoItem>();
        private string newTodo; //To get the title of the new todo item,  
                                //and bind it to the value of the text input using the bind 
                                //attribute in the <input> element

        private void AddTodo() {
            //Todo: add the todo
            if(!string.IsNullOrWhiteSpace(newTodo)){
                todos.Add(new TodoItem {Title = newTodo});
                newTodo = string.Empty;
            }
        }
    }
}