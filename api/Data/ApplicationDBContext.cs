using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        :base(dbContextOptions)
        {
            
        }
        
        public DbSet<Blog> Blog { get; set;}
        public DbSet<Motivationnotification> Motivationnotification { get; set;}
        public DbSet<Routes> Route {get; set;}
        public DbSet<Step> Step { get; set;}
        public DbSet<Stepgoal> Stepgoal { get; set;}
        public DbSet<User> User { get; set;}

    }
} 