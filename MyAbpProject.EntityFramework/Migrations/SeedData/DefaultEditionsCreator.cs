using System.Linq;
using Abp.Application.Editions;
using MyAbpProject.Editions;
using MyAbpProject.EntityFramework;

namespace MyAbpProject.Migrations.SeedData
{
    public class DefaultEditionsCreator
    {
        private readonly MyAbpProjectDbContext _context;

        public DefaultEditionsCreator(MyAbpProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }   
        }
    }
}