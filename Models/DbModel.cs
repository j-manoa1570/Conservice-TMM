using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TMM_Asp.Models;

namespace TMM_Asp.Data
{

    public class DBModel : DbContext
    {
        public DBModel() { }

        public DBModel(DbContextOptions<DBModel> options)
            : base(options)
        {

        }
        public DbSet<MemberModel> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=TeamMemberDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberModel>().ToTable("TeamMember");
        }
    }
}
