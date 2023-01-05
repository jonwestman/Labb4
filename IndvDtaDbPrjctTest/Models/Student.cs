using System;
using System.Collections.Generic;

namespace IndvDtaDbPrjctTest.Models
{
    public partial class Student
    {
        public int PkStudentId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string PersonNummer { get; set; } = null!;
        public int FkClassId { get; set; }

        public virtual Class FkClass { get; set; } = null!;
    }
}
