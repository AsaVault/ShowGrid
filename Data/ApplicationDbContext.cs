using Microsoft.EntityFrameworkCore;
using ShowGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowGrid.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserUpload> UserUpload { get; set; }
        public DbSet<UploadUser> UploadUser { get; set; }
        public DbSet<UploadList> UploadList { get; set; }
    }
}
