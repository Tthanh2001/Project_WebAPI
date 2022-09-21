using business.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private ITasksHandler _tasksHandler;

    public TaskController(ITasksHandler tasksHandler)
    {
        _tasksHandler = tasksHandler;
    }

    [HttpGet]
    [Route("GETALL")]
    public async Task<ActionResult> GetTask(int pageIndex, int pageSize)
    {
        /*            var list = await _myDbContext.Task.ToListAsync();

                    // phan trang
                    var excludeRows = (pageIndex - 1) * pageSize;
                    list = list.Skip(excludeRows).Take(pageSize).ToList();
                    var todos = AutoMapperUtil.AutoMap<Tasks, ModelAutoMapper>(list);
                    return Ok(todos);*/
        var x = await _tasksHandler.GetAllTasks(pageIndex, pageSize);      
        Console.WriteLine(x);
        return Ok(x);
    }

    [HttpPost]
    [Route("POST")]
    public async Task<ActionResult<Data.Tasks>> postTask([FromBody] ModelAutoMapper task)
    {
        await _tasksHandler.CreateTask(task);
        return Ok();
    }

    [HttpGet]
    [Route("GET")]
    public async Task<ActionResult> getTaskById(string name)
    {
        /*var task = await _myDbContext.Task.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(task);*/

        //return Ok(await _tasksHandler.GetTaskByName(name));
        return Ok();
    }

    [HttpPut]
    [Route("PUT")]
    public async Task<ActionResult<Data.Tasks>> putTask([FromBody] ModelAutoMapper task)
    {
        /*var task = await _myDbContext.Task.FirstOrDefaultAsync(x => x.Id == id);
        task.Name = model.Name;
        task.Status = model.Status;
        task.endDate = model.endDate;

        _myDbContext.Task.Update(task);
        await _myDbContext.SaveChangesAsync();
        return Ok(task);*/
        await _tasksHandler.UpdateTask(task);
        return Ok();
    }

    [HttpDelete]
    [Route("DELETE")]
    public async Task<ActionResult<Tasks>> removeTask(string name)
    {
        /*var task = await _myDbContext.Task.FirstOrDefaultAsync(x => x.Id == id);
        _myDbContext.Task.Remove(task);
        await _myDbContext.SaveChangesAsync();
        return Ok(task);*/
        await _tasksHandler.DeleteTask(name);
        return Ok();
    }

    [HttpGet]
    [Route("SEARCH")]
    public async Task<ActionResult> searchTask(string name)
    {
        /* var todo = await _myDbContext.Task.ToListAsync();
         if (!string.IsNullOrEmpty(name))
         {
             todo = todo.Where(s => s.Name!.Contains(name)).ToList();
         }
         return Ok(todo);*/

        return Ok(await _tasksHandler.GetTaskByName(name));
    }
}
