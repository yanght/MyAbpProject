using MyProject.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Migrations.SeedData
{
    public class DefaultTestDataForUser
    {
        private readonly MyProjectDbContext _context;

        private static readonly List<MyProject.Tasks.User> _users;

        public DefaultTestDataForUser(MyProjectDbContext context)
        {
            _context = context;
        }

        static DefaultTestDataForUser()
        {
            _users = new List<Tasks.User>()
            {
                new Tasks.User(){  UserName="yannis"},
                new Tasks.User(){ UserName="jack"}
            };
        }

        public void Create()
        {
            foreach (var user in _users)
            {
                if (_context.Users.FirstOrDefault(t => t.UserName == user.UserName) == null)
                {
                    _context.Users.Add(user);
                }
                _context.SaveChanges();

            }
        }
    }
}
