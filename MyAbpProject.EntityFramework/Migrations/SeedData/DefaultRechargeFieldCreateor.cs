using MyAbpProject.EntityFramework;
using MyAbpProject.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Migrations.SeedData
{
    public class DefaultRechargeFieldCreateor
    {
        private readonly MyAbpProjectDbContext _context;
        public DefaultRechargeFieldCreateor(MyAbpProjectDbContext context)
        {
            _context = context;
        }
        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            if (!_context.RechargeFields.Any())
            {
                for (int i = 1; i < 5; i++)
                {
                    RechargeField field = new RechargeField() { Amount = 5000 * i, IncrementAmount = 1500 * i, Integral = 100 * i };

                    _context.RechargeFields.Add(field);
                }
                _context.SaveChanges();
            }
        }
    }
}
