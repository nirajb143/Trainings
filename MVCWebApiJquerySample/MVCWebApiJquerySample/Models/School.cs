//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWebApiJquerySample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class School
    {
        public School()
        {
            this.SchoolDepartments = new HashSet<SchoolDepartment>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    
        public virtual ICollection<SchoolDepartment> SchoolDepartments { get; set; }
    }
}