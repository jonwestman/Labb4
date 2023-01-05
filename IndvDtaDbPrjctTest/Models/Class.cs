﻿using System;
using System.Collections.Generic;

namespace IndvDtaDbPrjctTest.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int PkClassId { get; set; }
        public string ClassName { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
