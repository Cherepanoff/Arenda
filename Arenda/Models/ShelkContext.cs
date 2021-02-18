using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Arenda.Models
{
    public partial class ShelkContext : DbContext
    {
        public ShelkContext()
        {
        }

        public ShelkContext(DbContextOptions<ShelkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arendator> Arendators { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WS-0687058;Initial Catalog=Shelk;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arendator>(entity =>
            {
                entity.ToTable("arendator");

                entity.Property(e => e.ArendatorId).HasColumnName("ArendatorID");

                entity.Property(e => e.AdressFact).IsUnicode(false);

                entity.Property(e => e.AdressLegal).IsUnicode(false);

                entity.Property(e => e.ArendatorFloor).IsUnicode(false);

                entity.Property(e => e.ArendatorName).IsUnicode(false);

                entity.Property(e => e.Commercial).IsUnicode(false);

                entity.Property(e => e.Communal).IsUnicode(false);

                entity.Property(e => e.Contact).IsUnicode(false);

                entity.Property(e => e.Contact1).IsUnicode(false);

                entity.Property(e => e.Curator).IsUnicode(false);

                entity.Property(e => e.DateContract).HasColumnType("date");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.GeneralDirector).IsUnicode(false);

                entity.Property(e => e.LegalPerson).IsUnicode(false);

                entity.Property(e => e.Marketing).IsUnicode(false);

                entity.Property(e => e.NumberContract).IsUnicode(false);

                entity.Property(e => e.Object).IsUnicode(false);

                entity.Property(e => e.PastArenda).IsUnicode(false);

                entity.Property(e => e.Post).IsUnicode(false);

                entity.Property(e => e.Rate).IsUnicode(false);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentFk).HasColumnName("CommentFK");

                entity.Property(e => e.CommentName).IsUnicode(false);

                entity.HasOne(d => d.CommentFkNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CommentFk)
                    .HasConstraintName("FK__Comment__Comment__2B3F6F97");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleFk).HasColumnName("RoleFK");

                entity.Property(e => e.UserLogin).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.HasOne(d => d.RoleFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleFk)
                    .HasConstraintName("FK__Users__RoleFK__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
