using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Oplog.Models
{


    public class OpLogContext : DbContext
    {
        public OpLogContext()
            : base("Data Source=localhost;Initial Catalog=OpLogDb;Integrated Security=SSPI;")
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<Log> Logs { get; set; }
    }

    public static class DbClass
    {
        public static OpLogContext Db()
        {
            var db = new OpLogContext();
            return db;
        }
    }
}