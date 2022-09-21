using System;
using System.Collections.Generic;

namespace WebApplicationAPI.Models
{
    public partial class Student
    {
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Major { get; set; } = null!;
        public string Andress { get; set; } = null!;
        public int Phone { get; set; }
        public string Email { get; set; } = null!;
        public string Course { get; set; } = null!;
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
