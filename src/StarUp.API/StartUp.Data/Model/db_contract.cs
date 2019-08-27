namespace StartUp.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("startup.db_contract")]
    public partial class db_contract
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public int target { get; set; }

        [Required]
        [StringLength(45)]
        public string userFrom { get; set; }

        [Required]
        [StringLength(45)]
        public string userTo { get; set; }

        public double price { get; set; }

        [Column(TypeName = "blob")]
        public byte[] picture { get; set; }

        public bool status { get; set; }

        [Required]
        [StringLength(45)]
        public string createdBy { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime createdDate { get; set; }

        public DateTime lastModifiedDate { get; set; }

        [Required]
        [StringLength(45)]
        public string lastModifiedBy { get; set; }

        public virtual db_user db_user { get; set; }

        public virtual db_user db_user1 { get; set; }

        public virtual db_user db_user2 { get; set; }

        public virtual db_user db_user3 { get; set; }
    }
}
