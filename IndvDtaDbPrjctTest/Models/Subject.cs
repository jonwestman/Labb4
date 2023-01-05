using System;
using System.Collections.Generic;

namespace IndvDtaDbPrjctTest.Models
{
    public partial class Subject
    {
        public int PkSubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public int FkDepartmentId { get; set; }

        public virtual Department FkDepartment { get; set; } = null!;
    }
}
