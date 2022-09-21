
using business.Tasks;
using Business;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAPI.Models;

public class TasksHandler : ITasksHandler
{
    private MyProjectDBContext _myDbContext;

    public TasksHandler(MyProjectDBContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public Task Creamodel(ModelAutoMapper taskModel)
    {
        throw new NotImplementedException();
    }

    public async Task CreateTask(ModelAutoMapper taskModel)
    {
        var todoListEntity = AutoMapperUtil.AutoMap<ModelAutoMapper, Tasks>(taskModel);
        _myDbContext.Task.Add(todoListEntity);
        await _myDbContext.SaveChangesAsync();
    }

    public async Task DeleteTask(string name)
    {
        var tasks = await _myDbContext.Task.FirstOrDefaultAsync(x => x.Name.Contains(name));
        _myDbContext.Task.Remove(tasks);
        await _myDbContext.SaveChangesAsync();
    }

    public async Task<List<ModelAutoMapper>> GetAllTasks(int pageIndex, int pageSize)
    {
        //var list = await _myDbContext.Task.ToListAsync();
        //var excludeRows = (pageIndex - 1) * pageSize;
        //list = list.Skip(excludeRows).Take(pageSize).ToList();
        //var todos = AutoMapperUtil.AutoMap<Task, ModelAutoMapper>(list);
        //return todos;
        return null;
    }


    public async Task UpdateTask(ModelAutoMapper taskModel)
    {
        var list = AutoMapperUtil.AutoMap<ModelAutoMapper, Tasks>(taskModel);
        _myDbContext.Task.Update(list);
        await _myDbContext.SaveChangesAsync();
    }

    public async Task<List<ModelAutoMapper>> GetTaskByName(string name)
    {
        var todo = await _myDbContext.Task.ToListAsync();
        if (!String.IsNullOrEmpty(name))
        {
            todo = todo.Where(s => s.Name!.Contains(name)).ToList();
        }
        var listTask = AutoMapperUtil.AutoMap<Tasks, ModelAutoMapper>(todo);
        return listTask;
    }
}

