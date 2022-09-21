using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("task")]
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Major { get; set; }
        public string Andress { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}