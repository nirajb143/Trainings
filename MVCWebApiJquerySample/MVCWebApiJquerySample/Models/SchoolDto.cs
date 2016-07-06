﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApiJquerySample.Models
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
}