namespace StartUp.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class StartUpModel : DbContext
    {
        public StartUpModel()
            : base("name=StartUpModel1")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<db_category> db_category { get; set; }
        public virtual DbSet<db_contract> db_contract { get; set; }
        public virtual DbSet<db_post> db_post { get; set; }
        public virtual DbSet<db_role> db_role { get; set; }
        public virtual DbSet<db_target> db_target { get; set; }
        public virtual DbSet<db_user> db_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<db_category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<db_category>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<db_category>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<db_category>()
                .Property(e => e.lastModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<db_category>()
                .HasMany(e => e.db_target)
                .WithRequired(e => e.db_category)
                .HasForeignKey(e => e.categoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_contract>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<db_contract>()
                .Property(e => e.userFrom)
                .IsUnicode(false);

            modelBuilder.Entity<db_contract>()
                .Property(e => e.userTo)
                .IsUnicode(false);

            modelBuilder.Entity<db_contract>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<db_contract>()
                .Property(e => e.lastModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<db_post>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<db_post>()
                .Property(e => e.owner)
                .IsUnicode(false);

            modelBuilder.Entity<db_post>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<db_post>()
                .Property(e => e.lastModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<db_role>()
                .Property(e => e.privilege)
                .IsUnicode(false);

            modelBuilder.Entity<db_role>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<db_role>()
                .HasMany(e => e.db_user)
                .WithRequired(e => e.db_role)
                .HasForeignKey(e => e.roleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_target>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<db_target>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<db_target>()
                .Property(e => e.createdBy)
                .IsUnicode(false);

            modelBuilder.Entity<db_target>()
                .Property(e => e.lastModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<db_target>()
                .HasMany(e => e.db_post)
                .WithRequired(e => e.db_target)
                .HasForeignKey(e => e.targetId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<db_user>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<db_user>()
                .Property(e => e.firtName)
                .IsUnicode(false);

            modelBuilder.Entity<db_user>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<db_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<db_user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<db_user>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_category)
                .WithRequired(e => e.db_user)
                .HasForeignKey(e => e.createdBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_category1)
                .WithRequired(e => e.db_user1)
                .HasForeignKey(e => e.lastModifiedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_contract)
                .WithRequired(e => e.db_user)
                .HasForeignKey(e => e.createdBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_contract1)
                .WithRequired(e => e.db_user1)
                .HasForeignKey(e => e.lastModifiedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_contract2)
                .WithRequired(e => e.db_user2)
                .HasForeignKey(e => e.userFrom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_contract3)
                .WithRequired(e => e.db_user3)
                .HasForeignKey(e => e.userTo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_post)
                .WithRequired(e => e.db_user)
                .HasForeignKey(e => e.createdBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_post1)
                .WithRequired(e => e.db_user1)
                .HasForeignKey(e => e.lastModifiedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_post2)
                .WithRequired(e => e.db_user2)
                .HasForeignKey(e => e.owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_target)
                .WithRequired(e => e.db_user)
                .HasForeignKey(e => e.createdBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<db_user>()
                .HasMany(e => e.db_target1)
                .WithRequired(e => e.db_user1)
                .HasForeignKey(e => e.lastModifiedBy)
                .WillCascadeOnDelete(false);
        }
    }
}
