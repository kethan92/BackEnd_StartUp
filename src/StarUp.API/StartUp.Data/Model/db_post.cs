namespace StartUp.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("startup.db_post")]
    public partial class db_post
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        public int targetId { get; set; }

        [Required]
        [StringLength(45)]
        public string owner { get; set; }

        public bool status { get; set; }

        [Required]
        [StringLength(45)]
        public string createdBy { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdDate { get; set; }

        public DateTime expiratedDate { get; set; }

        public DateTime lastModifiedDate { get; set; }

        [Required]
        [StringLength(45)]
        public string lastModifiedBy { get; set; }

        public virtual db_user db_user { get; set; }

        public virtual db_user db_user1 { get; set; }

        public virtual db_target db_target { get; set; }

        public virtual db_user db_user2 { get; set; }
    }
}
