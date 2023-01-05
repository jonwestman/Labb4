using System;
using System.Collections.Generic;

namespace IndvDtaDbPrjctTest.Models
{
    public partial class Faculty
    {
        public int PkFacultyId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public int FkFacultyTypeId { get; set; }
        public decimal Salary { get; set; }
        public int? FkEmployeeId { get; set; }

        public virtual EmploymentHistory? FkEmployee { get; set; }
        public virtual FacultyType FkFacultyType { get; set; } = null!;
    }
}
