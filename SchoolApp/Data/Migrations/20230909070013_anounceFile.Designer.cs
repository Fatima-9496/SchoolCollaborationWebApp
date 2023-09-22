﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolApp.Data;

#nullable disable

namespace SchoolApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230909070013_anounceFile")]
    partial class anounceFile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SchoolApp.Models.AnnounceAndProjView", b =>
                {
                    b.Property<int>("AnprId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnprId"), 1L, 1);

                    b.Property<int?>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("AnprId");

                    b.HasIndex("AnnouncementId");

                    b.HasIndex("ProjectId");

                    b.ToTable("AnnounceAndProjViews");
                });

            modelBuilder.Entity("SchoolApp.Models.Announcement", b =>
                {
                    b.Property<int>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnnouncementId"), 1L, 1);

                    b.Property<string>("AnnTearcherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnnouncementAuthor")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("AnnouncementDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnouncementFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnouncementTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("PostDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AnnouncementId");

                    b.HasIndex("AnnTearcherId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("SchoolApp.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<string>("ATearcherId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssignmentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("CourseIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignmentId");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CourseId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("SchoolApp.Models.AssignmentSubmission", b =>
                {
                    b.Property<int>("SubmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubmissionId"), 1L, 1);

                    b.Property<int?>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsSubmitted")
                        .HasColumnType("bit");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmissionFileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmissionText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubmissionId");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("AssignmentSubmissions");
                });

            modelBuilder.Entity("SchoolApp.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CTearcherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CourseMaterial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.HasIndex("CTearcherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchoolApp.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"), 1L, 1);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("SchoolApp.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("MediaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SchoolApp.Models.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("AppUserConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUsername")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolApp.Models.AnnounceAndProjView", b =>
                {
                    b.HasOne("SchoolApp.Models.Announcement", "Announcement")
                        .WithMany()
                        .HasForeignKey("AnnouncementId");

                    b.HasOne("SchoolApp.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.Navigation("Announcement");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SchoolApp.Models.Announcement", b =>
                {
                    b.HasOne("SchoolApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AnnTearcherId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("SchoolApp.Models.Assignment", b =>
                {
                    b.HasOne("SchoolApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("SchoolApp.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AppUser");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SchoolApp.Models.AssignmentSubmission", b =>
                {
                    b.HasOne("SchoolApp.Models.Assignment", "Assignment")
                        .WithMany("AssignmentSubmissions")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("AppUser");

                    b.Navigation("Assignment");
                });

            modelBuilder.Entity("SchoolApp.Models.Course", b =>
                {
                    b.HasOne("SchoolApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("CTearcherId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("SchoolApp.Models.Enrollment", b =>
                {
                    b.HasOne("SchoolApp.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("AppUser");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SchoolApp.Models.Project", b =>
                {
                    b.HasOne("SchoolApp.Models.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("SchoolApp.Models.Assignment", b =>
                {
                    b.Navigation("AssignmentSubmissions");
                });

            modelBuilder.Entity("SchoolApp.Models.Course", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
