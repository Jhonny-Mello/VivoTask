using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Vivo_Task.Shared_Static_Class.Enums
{
    public enum InputType
    {
        STRING = 0,
        NUMBER = 1,
        EMAIL = 2,
        PASSWORD = 3,
        DATE = 4,
        RANGE_DATE = 5
    }
}
