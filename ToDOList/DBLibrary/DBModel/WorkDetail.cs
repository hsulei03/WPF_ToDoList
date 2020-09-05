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
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string WorkContent { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string Important { get; set; }

        public DateTime? PlanDate { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime LastUpdataDate { get; set; }
    }
}
