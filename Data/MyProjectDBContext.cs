using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAPI.Models;

namespace Data
{
    public class MyProjectDBContext : DbContext
    {
        public MyProjectDBContext(DbContextOptions options) : base(options)
        {
        }

        #region DbSet

        public DbSet<Tasks> Task { get; set; }

        #endregion 
    }
}
