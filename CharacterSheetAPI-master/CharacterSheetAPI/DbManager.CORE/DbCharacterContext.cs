namespace DbManager.CORE
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using DbManager.CORE.Models;
    public partial class DbCharacterContext : IdentityDbContext
    {
       
        public DbCharacterContext(DbContextOptions<DbCharacterContext> options)
            : base(options)
        {
        }


        public virtual DbSet<ApiKeys> ApiKeys { get; set; }
        public virtual DbSet<AspUserEvent> AspUserEvent { get; set; }
        public virtual DbSet<CharactersSheets> CharactersSheets { get; set; }
        public virtual DbSet<EventsTable> EventsTable { get; set; }
        public virtual DbSet<Players> Players { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApiKeys>(entity =>
            {
                entity.ToTable("API_KEYS");

                entity.HasIndex(e => e.Apikey)
                    .HasName("APIKEY_UC")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apikey)
                    .HasColumnName("APIKEY")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AspUserIdFk)
                    .IsRequired()
                    .HasColumnName("Asp_User_id_FK")
                    .HasMaxLength(450);

                entity.Property(e => e.EventId).HasColumnName("Event_id");


                entity.HasOne(d => d.Event)
                    .WithMany(p => p.ApiKeys)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("API_KEY_EVENT_FK");
            });

            modelBuilder.Entity<AspUserEvent>(entity =>
            {
                entity.ToTable("ASP_USER_EVENT");

                entity.Property(e => e.AspUserEventId)
                    .HasColumnName("ASP_USER_EVENT_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AspUserIdFk)
                    .IsRequired()
                    .HasColumnName("Asp_User_id_FK")
                    .HasMaxLength(450);

                entity.Property(e => e.EventIdFk).HasColumnName("Event_id_FK");

                

                entity.HasOne(d => d.EventIdFkNavigation)
                    .WithMany(p => p.AspUserEvent)
                    .HasForeignKey(d => d.EventIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EVENT_FK");
            });

            modelBuilder.Entity<CharactersSheets>(entity =>
            {
                entity.HasKey(e => e.SheetId);

                entity.ToTable("CHARACTERS_SHEETS");

                entity.Property(e => e.SheetId)
                    .HasColumnName("Sheet_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Approved)
                    .HasColumnName("approved")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.EventIdFk).HasColumnName("Event_id_FK");

                entity.Property(e => e.Money)
                    .HasColumnName("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerIdFk).HasColumnName("Player_id_FK");

                entity.HasOne(d => d.EventIdFkNavigation)
                    .WithMany(p => p.CharactersSheets)
                    .HasForeignKey(d => d.EventIdFk)
                    .HasConstraintName("EVENT_CHARACTER_SHEET_FK");

                entity.HasOne(d => d.PlayerIdFkNavigation)
                    .WithMany(p => p.CharactersSheets)
                    .HasForeignKey(d => d.PlayerIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Event_Player_FK");
            });

            modelBuilder.Entity<EventsTable>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("EVENTS_TABLE");

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventDate)
                    .HasColumnName("event_date")
                    .HasColumnType("date");

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasColumnName("event_Description")
                    .HasMaxLength(2047)
                    .IsUnicode(false);

                entity.Property(e => e.EventTitle)
                    .HasColumnName("event_Title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("PLAYERS");

                entity.HasIndex(e => e.Email)
                    .HasName("EMAIL_UC")
                    .IsUnique();

                entity.Property(e => e.PlayerId)
                    .HasColumnName("Player_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AspUserIdFk)
                    .IsRequired()
                    .HasColumnName("Asp_User_id_FK")
                    .HasMaxLength(450);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(15)
                    .IsUnicode(false);

               
            });

        }
    }
}
