using GirifinDev.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Infra.Data.Context
{
    public class GirifinDevContext:DbContext
    {
        public GirifinDevContext(DbContextOptions<GirifinDevContext> options):base(options)
        {
            
        }
        public DbSet<_CategoryProject> CategoryProjects { get; set; }
        public DbSet<_PageComment> PageComments { get; set; }
        public DbSet<_Project> Projects { get; set; }
        public DbSet<_User> Users { get; set; }
    }
}
