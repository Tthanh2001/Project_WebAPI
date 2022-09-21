namespace business.Tasks
{
    public interface ITasksHandler
    {
        Task<List<ModelAutoMapper>> GetAllTasks(int pageIndex, int pageSize);
        Task CreateTask(ModelAutoMapper taskModel);
        Task Creamodel(ModelAutoMapper taskModel);
        Task UpdateTask(ModelAutoMapper taskModel);

        Task DeleteTask(string name);


        Task<List<ModelAutoMapper>> GetTaskByName(string name);
    }
}
