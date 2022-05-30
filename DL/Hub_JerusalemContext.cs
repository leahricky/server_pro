using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Entity { 
    public partial class Hub_JerusalemContext : DbContext
    {
        public Hub_JerusalemContext()
        {
        }

        public Hub_JerusalemContext(DbContextOptions<Hub_JerusalemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DayRoomBooking> DayRoomBookings { get; set; }
        public virtual DbSet<MarriageStatus> MarriageStatuses { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomBooking> RoomBookings { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkingStatus> WorkingStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=srv2\\PUPILS;Database=Hub_Jerusalem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<DayRoomBooking>(entity =>
            {
                entity.ToTable("Day_Room_booking");

                entity.Property(e => e.IdRoomBooking).HasColumnName("Id_Room_booking");

                entity.HasOne(d => d.IdRoomBookingNavigation)
                    .WithMany(p => p.DayRoomBookings)
                    .HasForeignKey(d => d.IdRoomBooking)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Day_Room_booking_Room_booking");
            });

            modelBuilder.Entity<MarriageStatus>(entity =>
            {
                entity.ToTable("Marriage_status");

                entity.Property(e => e.MarriageStatus1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Marriage_status");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("HOST");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("PATH");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("REFERER");

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdRoomType).HasColumnName("Id_Room_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.XEndPoint).HasColumnName("X_end_point");

                entity.Property(e => e.XStartPoint).HasColumnName("X_start_point");

                entity.Property(e => e.YEndPoint).HasColumnName("Y_end_point");

                entity.Property(e => e.YStartPoint).HasColumnName("Y_start_point");

                entity.HasOne(d => d.IdRoomTypeNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.IdRoomType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rooms_Room_type");
            });

            modelBuilder.Entity<RoomBooking>(entity =>
            {
                entity.ToTable("Room_booking");

                entity.Property(e => e.EndDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("End_dateTime");

                entity.Property(e => e.IdRoom).HasColumnName("Id_room");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Id_user")
                    .IsFixedLength(true);

                entity.Property(e => e.StartDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_dateTime");

                entity.Property(e => e.TimeDeviation)
                    .HasColumnName("Time_deviation")
                    .HasDefaultValueSql("((15))");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.IdRoom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_booking_Rooms");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.RoomBookings)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_idUser");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.ToTable("Room_type");

                entity.Property(e => e.RoomType1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Room_type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdNumber);

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Id_number")
                    .IsFixedLength(true);

                entity.Property(e => e.Fingerprint).HasColumnType("image");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("First_name");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdMarriageStatus).HasColumnName("Id_Marriage_status");

                entity.Property(e => e.IdWorkingStatus).HasColumnName("Id_Working_status");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Last_name");

                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.PermanentWorker).HasColumnName("Permanent_worker");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdMarriageStatusNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdMarriageStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Marriage_status");

                entity.HasOne(d => d.IdWorkingStatusNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdWorkingStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Working_status");
            });

            modelBuilder.Entity<WorkingStatus>(entity =>
            {
                entity.ToTable("Working_status");

                entity.Property(e => e.WorkingStatus1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Working_status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
