﻿using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Tasks.Dtos
{

    public  class GetTasksOutput
    {
        public List<TaskDto> Tasks { get; set; }
    }
}
