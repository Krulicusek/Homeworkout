﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using homeWorkOutApi.Net6._0.Data;

#nullable disable

namespace HomeWorkoutBackend.Migrations
{
    [DbContext(typeof(HomeWorkoutContext))]
    [Migration("20221116194417_addUsersAndRoles")]
    partial class addUsersAndRoles
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeWorkoutModels.Models.ExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseModel");
                });

            modelBuilder.Entity("HomeWorkoutModels.Models.HomeworkModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseModelId")
                        .HasColumnType("int");

                    b.Property<int?>("HomeworkSequenceModelId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfTimes")
                        .HasColumnType("int");

                    b.Property<int>("PlaceInSequence")
                        .HasColumnType("int");

                    b.Property<int>("Seconds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HomeworkSequenceModelId");

                    b.ToTable("HomeworkModel");
                });

            modelBuilder.Entity("HomeWorkoutModels.Models.HomeworkSequenceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstimatedTimeInMinutes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HomeworkSequenceModel");
                });

            modelBuilder.Entity("HomeWorkoutModels.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HomeWorkoutModels.Models.HomeworkModel", b =>
                {
                    b.HasOne("HomeWorkoutModels.Models.HomeworkSequenceModel", null)
                        .WithMany("HomeworkICollection")
                        .HasForeignKey("HomeworkSequenceModelId");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.HasOne("HomeWorkoutModels.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HomeWorkoutModels.Models.HomeworkSequenceModel", b =>
                {
                    b.Navigation("HomeworkICollection");
                });
#pragma warning restore 612, 618
        }
    }
}
