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

        [Required]
        public string WorkContent { get; set; }

        [Required]
        [StringLength(1)]
        public string Important { get; set; }
    }
}
