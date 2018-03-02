using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Authorization
{
    public class PermissionDefined : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }
    }
}
