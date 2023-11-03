﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using N67.Persistence.DataContexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace N67.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231102162858_AddLocationData")]
    partial class AddLocationData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("N67.Domain.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("N67.Domain.Entities.CourseStudent", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("N67.Domain.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77589501-22b7-4fa2-9436-534c0c46913e"),
                            Name = "Uzbekistan",
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("33517080-5e99-4591-b85d-2ed1ebf3bd98"),
                            Name = "Tashkent",
                            ParentId = new Guid("77589501-22b7-4fa2-9436-534c0c46913e"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("5eccba7f-4361-4ee6-832f-35ab309786cd"),
                            Name = "Navoiy",
                            ParentId = new Guid("77589501-22b7-4fa2-9436-534c0c46913e"),
                            Type = 1
                        });
                });

            modelBuilder.Entity("N67.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("N67.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("N67.Domain.Entities.Course", b =>
                {
                    b.HasOne("N67.Domain.Entities.User", "Teacher")
                        .WithMany("TeacherCourses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("N67.Domain.Entities.CourseStudent", b =>
                {
                    b.HasOne("N67.Domain.Entities.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("N67.Domain.Entities.User", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("N67.Domain.Entities.Location", b =>
                {
                    b.HasOne("N67.Domain.Entities.Location", "ParentLocation")
                        .WithMany("ChildrenLocations")
                        .HasForeignKey("ParentId");

                    b.Navigation("ParentLocation");
                });

            modelBuilder.Entity("N67.Domain.Entities.Role", b =>
                {
                    b.HasOne("N67.Domain.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("N67.Domain.Entities.Role", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("N67.Domain.Entities.Course", b =>
                {
                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("N67.Domain.Entities.Location", b =>
                {
                    b.Navigation("ChildrenLocations");
                });

            modelBuilder.Entity("N67.Domain.Entities.User", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("TeacherCourses");
                });
#pragma warning restore 612, 618
        }
    }
}