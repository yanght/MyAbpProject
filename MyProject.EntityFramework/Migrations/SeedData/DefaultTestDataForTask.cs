using MyProject.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Migrations.SeedData
{
    public class DefaultTestDataForTask
    {
        private readonly MyProjectDbContext _context;

        private static readonly List<MyProject.Tasks.Task> _tasks;

        public DefaultTestDataForTask(MyProject.EntityFramework.MyProjectDbContext context)
        {
            _context = context;
        }

        static DefaultTestDataForTask()
        {
            _tasks = new List<MyProject.Tasks.Task>()
            {
                new MyProject.Tasks.Task("Learning ABP deom", "Learning how to use abp framework to build a MPA application."),
                new MyProject.Tasks.Task("Make Lunch", "Cook 2 dishs")
            };
        }

        public void Create()
        {
            foreach (var task in _tasks)
            {
                if (_context.Tasks.FirstOrDefault(t => t.Title == task.Title) == null)
                {
                    _context.Tasks.Add(task);
                }
                _context.SaveChanges();
            }
        }
    }
}
