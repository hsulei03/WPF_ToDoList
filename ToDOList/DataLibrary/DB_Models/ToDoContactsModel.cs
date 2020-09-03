namespace DataLibrary.DB_Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoContactsModel : DbContext
    {
        public ToDoContactsModel()
            : base("name=ToDoContactsModel")
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
