using System;
using System.Collections.Generic;

namespace IndvDtaDbPrjctTest.Models
{
    public partial class StudentGrade
    {
        public int FkStudentId { get; set; }
        public int FkFacultyId { get; set; }
        public DateTime DateOfGrade { get; set; }
        public int FkGradeId { get; set; }
        public int FkSubjectId { get; set; }

        public virtual Faculty FkFaculty { get; set; } = null!;
        public virtual Grade FkGrade { get; set; } = null!;
        public virtual Student FkStudent { get; set; } = null!;
        public virtual Subject FkSubject { get; set; } = null!;
    }
}
