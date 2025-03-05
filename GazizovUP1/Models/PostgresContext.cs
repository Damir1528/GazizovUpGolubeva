using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GazizovUP1.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<DirectionType> DirectionTypes { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Jury> Juries { get; set; }

    public virtual DbSet<Logined> Logineds { get; set; }

    public virtual DbSet<Meropriyatiye> Meropriyatiyes { get; set; }

    public virtual DbSet<Moderator> Moderators { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("action_pk");

            entity.ToTable("action");

            entity.Property(e => e.ActionId).HasColumnName("action_id");
            entity.Property(e => e.ActionDateStart).HasColumnName("action_date_start");
            entity.Property(e => e.ActionSpisok).HasColumnName("action_spisok");
            entity.Property(e => e.ActionTitle).HasColumnName("action_title");
            entity.Property(e => e.ActionWinner).HasColumnName("action_winner");
        });

        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("activities_pkey");

            entity.ToTable("activities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activity1)
                .HasColumnType("character varying")
                .HasColumnName("activity");
            entity.Property(e => e.Activityday).HasColumnName("activityday");
            entity.Property(e => e.Countdays).HasColumnName("countdays");
            entity.Property(e => e.Expert1).HasColumnName("expert1");
            entity.Property(e => e.Expert2).HasColumnName("expert2");
            entity.Property(e => e.Expert3).HasColumnName("expert3");
            entity.Property(e => e.Expert4).HasColumnName("expert4");
            entity.Property(e => e.Expert5).HasColumnName("expert5");
            entity.Property(e => e.Moderator).HasColumnName("moderator");
            entity.Property(e => e.NameEvent).HasColumnName("name_event");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Starttime).HasColumnName("starttime");
            entity.Property(e => e.Winner).HasColumnName("winner");

            entity.HasOne(d => d.Expert1Navigation).WithMany(p => p.ActivityExpert1Navigations)
                .HasForeignKey(d => d.Expert1)
                .HasConstraintName("activities_expert1_fkey");

            entity.HasOne(d => d.Expert2Navigation).WithMany(p => p.ActivityExpert2Navigations)
                .HasForeignKey(d => d.Expert2)
                .HasConstraintName("activities_expert2_fkey");

            entity.HasOne(d => d.Expert3Navigation).WithMany(p => p.ActivityExpert3Navigations)
                .HasForeignKey(d => d.Expert3)
                .HasConstraintName("activities_expert3_fkey");

            entity.HasOne(d => d.Expert4Navigation).WithMany(p => p.ActivityExpert4Navigations)
                .HasForeignKey(d => d.Expert4)
                .HasConstraintName("activities_expert4_fkey");

            entity.HasOne(d => d.Expert5Navigation).WithMany(p => p.ActivityExpert5Navigations)
                .HasForeignKey(d => d.Expert5)
                .HasConstraintName("activities_expert5_fkey");

            entity.HasOne(d => d.ModeratorNavigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.Moderator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("activities_moderator_fkey");

            entity.HasOne(d => d.NameEventNavigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.NameEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("activities_name_event_fkey");

            entity.HasOne(d => d.WinnerNavigation).WithMany(p => p.Activities)
                .HasForeignKey(d => d.Winner)
                .HasConstraintName("activities_winner_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("country_pk");

            entity.ToTable("country");

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryEnName)
                .HasColumnType("character varying")
                .HasColumnName("country_en_name");
            entity.Property(e => e.CountryKod)
                .HasColumnType("character varying")
                .HasColumnName("country_kod");
            entity.Property(e => e.CountryKod2).HasColumnName("country_kod2");
            entity.Property(e => e.CountryName)
                .HasColumnType("character varying")
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<DirectionType>(entity =>
        {
            entity.HasKey(e => e.DirectionId).HasName("direction_type_pk");

            entity.ToTable("direction_type");

            entity.Property(e => e.DirectionId).HasColumnName("direction_id");
            entity.Property(e => e.DirectionTitle)
                .HasColumnType("character varying")
                .HasColumnName("direction_title");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventsId).HasName("events_pk");

            entity.ToTable("events");

            entity.Property(e => e.EventsId)
                .ValueGeneratedNever()
                .HasColumnName("events_id");
            entity.Property(e => e.EventsName)
                .HasMaxLength(255)
                .HasColumnName("events_name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("gender_pk");

            entity.ToTable("gender");

            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.GenderTitle)
                .HasColumnType("character varying")
                .HasColumnName("gender_title");
        });

        modelBuilder.Entity<Jury>(entity =>
        {
            entity.HasKey(e => e.JuryId).HasName("jury_pk");

            entity.ToTable("jury");

            entity.Property(e => e.JuryId)
                .ValueGeneratedOnAdd()
                .HasColumnName("jury_id");
            entity.Property(e => e.JuryDirection).HasColumnName("jury_direction");

            entity.HasOne(d => d.JuryDirectionNavigation).WithMany(p => p.Juries)
                .HasForeignKey(d => d.JuryDirection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jury_direction_type_fk");

            entity.HasOne(d => d.JuryNavigation).WithOne(p => p.Jury)
                .HasForeignKey<Jury>(d => d.JuryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("jury_users_fk");
        });

        modelBuilder.Entity<Logined>(entity =>
        {
            entity.HasKey(e => e.LoginedId).HasName("logined_pk");

            entity.ToTable("logined");

            entity.Property(e => e.LoginedId).HasColumnName("logined_id");
            entity.Property(e => e.LoginedPassword)
                .HasColumnType("character varying")
                .HasColumnName("logined_password");
            entity.Property(e => e.LoginedRole).HasColumnName("logined_role");

            entity.HasOne(d => d.LoginedRoleNavigation).WithMany(p => p.Logineds)
                .HasForeignKey(d => d.LoginedRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("logined_roles_fk");
        });

        modelBuilder.Entity<Meropriyatiye>(entity =>
        {
            entity.HasKey(e => e.MeropriyatiyeId).HasName("meropriyatiye_pk");

            entity.ToTable("meropriyatiye");

            entity.Property(e => e.MeropriyatiyeId).HasColumnName("meropriyatiye_id");
            entity.Property(e => e.MeropriyatiyeCity).HasColumnName("meropriyatiye_city");
            entity.Property(e => e.MeropriyatiyeDate).HasColumnName("meropriyatiye_date");
            entity.Property(e => e.MeropriyatiyeDays).HasColumnName("meropriyatiye_days");
            entity.Property(e => e.MeropriyatiyeEvent).HasColumnName("meropriyatiye_event");
            entity.Property(e => e.MeropriyatiyeName)
                .HasColumnType("character varying")
                .HasColumnName("meropriyatiye_name");

            entity.HasOne(d => d.MeropriyatiyeEventNavigation).WithMany(p => p.Meropriyatiyes)
                .HasForeignKey(d => d.MeropriyatiyeEvent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("meropriyatiye_events_fk");
        });

        modelBuilder.Entity<Moderator>(entity =>
        {
            entity.HasKey(e => e.ModeratorId).HasName("moderators_pk");

            entity.ToTable("moderators");

            entity.Property(e => e.ModeratorId)
                .ValueGeneratedOnAdd()
                .HasColumnName("moderator_id");
            entity.Property(e => e.ModeratorDirection).HasColumnName("moderator_direction");
            entity.Property(e => e.ModeratorEvents).HasColumnName("moderator_events");

            entity.HasOne(d => d.ModeratorDirectionNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.ModeratorDirection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moderators_direction_type_fk");

            entity.HasOne(d => d.ModeratorEventsNavigation).WithMany(p => p.Moderators)
                .HasForeignKey(d => d.ModeratorEvents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moderators_events_fk");

            entity.HasOne(d => d.ModeratorNavigation).WithOne(p => p.Moderator)
                .HasForeignKey<Moderator>(d => d.ModeratorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("moderators_users_fk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("roles_pk");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.UsersId)
                .ValueGeneratedOnAdd()
                .HasColumnName("users_id");
            entity.Property(e => e.UsersBirthday).HasColumnName("users_birthday");
            entity.Property(e => e.UsersCountry).HasColumnName("users_country");
            entity.Property(e => e.UsersEmail)
                .HasColumnType("character varying")
                .HasColumnName("users_email");
            entity.Property(e => e.UsersFio)
                .HasColumnType("character varying")
                .HasColumnName("users_fio");
            entity.Property(e => e.UsersGender).HasColumnName("users_gender");
            entity.Property(e => e.UsersImage)
                .HasColumnType("character varying")
                .HasColumnName("users_image");
            entity.Property(e => e.UsersPhone)
                .HasColumnType("character varying")
                .HasColumnName("users_phone");

            entity.HasOne(d => d.UsersCountryNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UsersCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_country_fk");

            entity.HasOne(d => d.UsersGenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UsersGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_gender_fk");

            entity.HasOne(d => d.Users).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_logined_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
