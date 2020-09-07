namespace DBLibrary.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkDetail")]
    public partial class WorkDetail
    {
        public int Id { get; set; }

        public string WorkContent { get; set; }

        [StringLength(1)]
        public string Important { get; set; }

        [StringLength(1)]
        public string Complete { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PlanDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
