using MyAbpProject.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MyAbpProject.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly MyAbpProjectDbContext _context;

        public InitialHostDbBuilder(MyAbpProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
