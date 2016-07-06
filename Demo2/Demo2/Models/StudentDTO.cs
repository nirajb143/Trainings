using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo2.Models
{
    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
        public string EnrollYear { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}