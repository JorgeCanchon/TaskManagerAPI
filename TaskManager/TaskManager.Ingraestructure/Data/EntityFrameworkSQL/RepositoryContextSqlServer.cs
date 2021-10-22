using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Infraestructure.Data.EntityFrameworkSQL
{
    public class RepositoryContextSqlServer : DbContext
    {
        public RepositoryContextSqlServer()
        {

        }
        public RepositoryContextSqlServer(DbContextOptions options)
            : base(options)
        {

        }
        public virtual DbSet<TaskEntity> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if (modelBuilder != null)
            {
                modelBuilder.HasAnnotation("Sqlite:Autoincrement", true)
                .HasAnnotation("MySql:ValueGeneratedOnAdd", true)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.IdentityColumn);
            }
        }
    }
}
