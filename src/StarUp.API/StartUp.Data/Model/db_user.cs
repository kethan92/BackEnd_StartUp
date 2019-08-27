namespace StartUp.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("startup.db_user")]
    public partial class db_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public db_user()
        {
            db_category = new HashSet<db_category>();
            db_category1 = new HashSet<db_category>();
            db_contract = new HashSet<db_contract>();
            db_contract1 = new HashSet<db_contract>();
            db_contract2 = new HashSet<db_contract>();
            db_contract3 = new HashSet<db_contract>();
            db_post = new HashSet<db_post>();
            db_post1 = new HashSet<db_post>();
            db_post2 = new HashSet<db_post>();
            db_target = new HashSet<db_target>();
            db_target1 = new HashSet<db_target>();
        }

        [Key]
        [StringLength(45)]
        public string userName { get; set; }

        [Required]
        [StringLength(255)]
        public string passWord { get; set; }

        [Required]
        [StringLength(45)]
        public string firtName { get; set; }

        [Required]
        [StringLength(45)]
        public string lastName { get; set; }

        [Column(TypeName = "blob")]
        public byte[] certificated { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(12)]
        public string phone { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [Column(TypeName = "blob")]
        public byte[] avatar { get; set; }

        public int roleId { get; set; }

        public bool status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_category> db_category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_category> db_category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_contract> db_contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_contract> db_contract1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_contract> db_contract2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_contract> db_contract3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_post> db_post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_post> db_post1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_post> db_post2 { get; set; }

        public virtual db_role db_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_target> db_target { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<db_target> db_target1 { get; set; }
    }
}
