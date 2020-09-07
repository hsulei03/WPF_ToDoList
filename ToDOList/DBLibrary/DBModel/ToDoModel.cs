namespace DBLibrary.DBModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoModel : DbContext
    {
        public ToDoModel()
            : base("name=ToDoModel")
        {
        }

        public virtual DbSet<WorkDetail> WorkDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkDetail>()
                .Property(e => e.Important)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<WorkDetail>()
                .Property(e => e.Complete)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
