using System;
using System.Collections.Generic;

namespace IndvDtaDbPrjctTest.Models
{
    public partial class Credential
    {
        public int PkUserId { get; set; }
        public string UserName { get; set; } = null!;
        public string PassWord { get; set; } = null!;
    }
}
