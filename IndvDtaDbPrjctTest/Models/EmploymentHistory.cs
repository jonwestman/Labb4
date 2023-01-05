using System;
using System.Collections.Generic;

namespace IndvDtaDbPrjctTest.Models
{
    public partial class EmploymentHistory
    {
        public EmploymentHistory()
        {
            Faculties = new HashSet<Faculty>();
        }

        public int PkEmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public int FkDepartmentId { get; set; }

        public virtual Department FkDepartment { get; set; } = null!;
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
