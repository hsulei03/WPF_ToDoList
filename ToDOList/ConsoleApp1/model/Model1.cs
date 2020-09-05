namespace ConsoleApp1.model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<WorkDetail> WorkDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkDetail>()
                .Property(e => e.Important)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
