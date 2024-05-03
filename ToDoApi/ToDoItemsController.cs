using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class ToDoItemsController : ControllerBase{

[HttpGet("getToDoItems")]
public ActionResult<IEnumerable<ToDoItem>> GetTodoItems()
{
    var items = new List<ToDoItem>{
        new ToDoItem(){Id = 1, Name = "Reading"},
        new ToDoItem(){Id = 2, Name = "Working"},
    };

    return items;
}

[HttpGet("getToDoItem={id}")]
public ActionResult<ToDoItem> GetTodoItem(int id)
{
    var items = new List<ToDoItem>{
        new ToDoItem(){Id = 1, Name = "Reading"},
        new ToDoItem(){Id = 2, Name = "Working"},
    };

    return items.First(x => x.Id == id);
}
[HttpPost]
public ActionResult<IEnumerable<ToDoItem>> AddToDoItem(ToDoItem item){
    var items = new List<ToDoItem>{
        new ToDoItem(){Id = 1, Name = "Reading"},
        new ToDoItem(){Id = 2, Name = "Working"},
    };

    items.Add(item);
    return items;
}

[HttpPut]
public ActionResult<IEnumerable<ToDoItem>> UpdateToDoItem(ToDoItem item){
    var items = new List<ToDoItem>{
        new(){Id = 1, Name = "Reading"},
        new(){Id = 2, Name = "Working"},
    };
    var itemToUpdate = items.FirstOrDefault(x => x.Id == item.Id);
    if(itemToUpdate != null){
      items.ForEach(x => {
            if(x.Id == itemToUpdate.Id){
                x.Name = item.Name;
            }
        });
    }
    else{
        items.Add(item);
    }
    return items;
}

[HttpDelete("{id}")]
public ActionResult<IEnumerable<ToDoItem>> DeleteToDoItem(int id){
    var items = new List<ToDoItem>{
        new(){Id = 1, Name = "Reading"},
        new(){Id = 2, Name = "Working"},
    };
    var itemToDelete = items.FirstOrDefault(x => x.Id == id);
    if(itemToDelete != null){
      items.Remove(itemToDelete);
    }
   return items;
}
}