using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReservationRestApi.Models
{
    public partial class ReservationRestApiContext : DbContext
    {
        public ReservationRestApiContext()
        {
        }

        public ReservationRestApiContext(DbContextOptions<ReservationRestApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ReservationDate> ReservationDate { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8BK3PKQ ;Database=ReservationRestApi;Trusted_Connection=True;");
            }
        }
        // model update command
        //Scaffold-DbContext "Server=DESKTOP-8BK3PKQ ;Database=ReservationRestApi;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationDate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndReservation)
                    .HasColumnName("endReservation")
                    .HasColumnType("date");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.Property(e => e.StartReservarion)
                    .HasColumnName("startReservarion")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.ReservationDate)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Reservati__roomI__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReservationDate)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Reservati__user___47DBAE45");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Number).HasColumnName("number");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });
        }
    }
}
