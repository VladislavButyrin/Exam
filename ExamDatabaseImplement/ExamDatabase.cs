using ExamDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;


namespace ExamDatabaseImplement
{
    public class ExamDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;InitialCatalog=ExamDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<First> Firsts { set; get; }
        public virtual DbSet<Second> Seconds { set; get; }
    }
}
