using MyAbpProject.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Users.Dto
{
    public class GetUsersInput : PagedSortedAndFilteredInputDto
    {
        public string UserName { get; set; }
    }
}
