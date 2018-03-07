using Abp.Application.Navigation;
using System.Collections.Generic;

namespace MyAbpProject.Web.Models.Layout
{
    public class SideBarNavViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}