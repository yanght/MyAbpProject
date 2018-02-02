using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Events
{
    public class ActivityWriter : IEventHandler<TaskCompletedEventData>, ITransientDependency
    {
        public void HandleEvent(TaskCompletedEventData eventData)
        {
                
        }
    }
}
