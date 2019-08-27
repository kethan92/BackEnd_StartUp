namespace StartUp.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("startup.db_category")]
    public partial class db_category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public db_category()
        {
            db_target = new HashSet<db_target>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(45)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string description { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_target> db_target { get; set; }

        public virtual db_user db_user { get; set; }

        public virtual db_user db_user1 { get; set; }
    }
}
