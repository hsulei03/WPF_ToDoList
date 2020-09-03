namespace DataLibrary.DB_Models
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

        [Required]
        public string WorkContent { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PlanDate { get; set; }

        [StringLength(1)]
        public string Important { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationDate { get; set; }

        public DateTime LastUpdataDate { get; set; }
    }
}
