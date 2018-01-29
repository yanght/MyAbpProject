using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Timing;
using AutoMapper;
using MyProject.IRepositories;
using MyProject.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tasks
{
    public class TaskAppService : MyProjectAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public int CreateTask(CreateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            //Creating a new Task entity with given input's properties
            var task = new Task
            {
                Description = input.Description,
                Title = input.Title,
                State = input.State,
                CreationTime = Clock.Now
            };

            //Saving entity with standard Insert method of repositories.
            return _taskRepository.InsertAndGetId(task);

        }

        public void DeleteTask(int taskId)
        {
            var task = _taskRepository.Get(taskId);
            if (task != null)
            {
                _taskRepository.Delete(task);
            }
        }

        public IList<TaskDto> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public TaskDto GetTaskById(int taskId)
        {
            //Called specific GetAllWithPeople method of task repository.
            var task = _taskRepository.Get(taskId);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return task.MapTo<TaskDto>();
        }

        public async Task<TaskDto> GetTaskByIdAsync(int taskId)
        {
            //Called specific GetAllWithPeople method of task repository.
            var task = await _taskRepository.GetAsync(taskId);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return task.MapTo<TaskDto>();

        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            var query = _taskRepository.GetAll();

            if (input.AssignedPersonId.HasValue)
            {
                query = query.Where(t => t.AssignedPersonId == input.AssignedPersonId.Value);
            }

            if (input.State.HasValue)
            {
                query = query.Where(t => t.State == input.State.Value);
            }

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetTasksOutput
            {
                Tasks = Mapper.Map<List<TaskDto>>(query.ToList())
            };
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService base class.
            Logger.Info("Updating a task for input: " + input);

            //Retrieving a task entity with given id using standard Get method of repositories.
            var task = _taskRepository.Get(input.Id);

            //Updating changed properties of the retrieved task entity.

            if (input.State.HasValue)
            {
                task.State = input.State.Value;
            }

        }
    }
}
