﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Models
{
    public class AuthenticateRequestAndResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
