using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RoutingSample.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Salary")]
        public double Salary { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Mobile")]
        public string Contact { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }
    }
}