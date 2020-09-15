namespace Server01.DBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<ChatImages> ChatImages { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Message> Message { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Contacts)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.ContactId);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Contacts1)
                .WithOptional(e => e.Account1)
                .HasForeignKey(e => e.OwnerId);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Message)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.DeliverId);

            modelBuilder.Entity<ChatImages>()
                .HasMany(e => e.Chat)
                .WithOptional(e => e.ChatImages)
                .HasForeignKey(e => e.ImageId);
        }
    }
}
