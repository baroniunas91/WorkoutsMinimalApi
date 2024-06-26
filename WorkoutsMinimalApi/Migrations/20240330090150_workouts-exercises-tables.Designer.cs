﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkoutsMinimalApi.ContextConfigurations;

#nullable disable

namespace WorkoutsMinimalApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240330090150_workouts-exercises-tables")]
    partial class workoutsexercisestables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WorkoutsMinimalApi.Entities.ExerciseEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Duration")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("duration");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<int>("Reps")
                        .HasColumnType("int")
                        .HasColumnName("reps");

                    b.Property<int>("Sets")
                        .HasColumnType("int")
                        .HasColumnName("sets");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("exercises", (string)null);
                });

            modelBuilder.Entity("WorkoutsMinimalApi.Entities.WorkoutEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("workouts", (string)null);
                });

            modelBuilder.Entity("WorkoutsMinimalApi.Entities.ExerciseEntity", b =>
                {
                    b.HasOne("WorkoutsMinimalApi.Entities.WorkoutEntity", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("WorkoutsMinimalApi.Entities.WorkoutEntity", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
