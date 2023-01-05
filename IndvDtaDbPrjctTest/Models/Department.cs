using System;
using System.Collections.Generic;

namespace IndvDtaDbPrjctTest.Models
{
    public partial class Department
    {
        public Department()
        {
            EmploymentHistories = new HashSet<EmploymentHistory>();
            Subjects = new HashSet<Subject>();
        }

        public int PkDepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public decimal? Budget { get; set; }

        public virtual ICollection<EmploymentHistory> EmploymentHistories { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
