﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Application.App
{
    public interface ILocalizationService
    {
        string L(string name, params object[] args);
    }
}
