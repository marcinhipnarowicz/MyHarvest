﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyHarvestApi.Entity.Context;

namespace MyHarvestApi.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201208184831_InitialNewDatabase2")]
    partial class InitialNewDatabase2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyHarvestApi.Entity.Model.AccountType", b =>
                {
                    b.Property<int>("IdAccountType")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("IdAccountType");

                    b.ToTable("AccountTypes");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.Plot", b =>
                {
                    b.Property<int>("IdPlot")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("IdPlot");

                    b.ToTable("Plots");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.StatusOfTask", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("IdStatus");

                    b.ToTable("StatusOfTasks");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.Task", b =>
                {
                    b.Property<int>("IdTask")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("IdPlot");

                    b.Property<string>("Name");

                    b.HasKey("IdTask");

                    b.HasIndex("IdPlot");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<int>("IdAccountType");

                    b.Property<int?>("IdBoss");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Surname");

                    b.HasKey("IdUser");

                    b.HasIndex("IdAccountType");

                    b.HasIndex("IdBoss");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.UserInformation", b =>
                {
                    b.Property<int>("IdUserInformation")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area");

                    b.Property<int?>("IdTask");

                    b.Property<int?>("IdTaskStatus");

                    b.Property<int?>("IdUser");

                    b.HasKey("IdUserInformation");

                    b.HasIndex("IdTask");

                    b.HasIndex("IdTaskStatus");

                    b.HasIndex("IdUser");

                    b.ToTable("UsersInformation");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.UserTask", b =>
                {
                    b.Property<int>("IdUserTask")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdTask");

                    b.Property<int?>("IdUser");

                    b.HasKey("IdUserTask");

                    b.HasIndex("IdTask");

                    b.HasIndex("IdUser");

                    b.ToTable("UsersTasks");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.Task", b =>
                {
                    b.HasOne("MyHarvestApi.Entity.Model.Plot", "Plot")
                        .WithMany()
                        .HasForeignKey("IdPlot");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.User", b =>
                {
                    b.HasOne("MyHarvestApi.Entity.Model.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("IdAccountType")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyHarvestApi.Entity.Model.User", "Boss")
                        .WithMany("Replies")
                        .HasForeignKey("IdBoss");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.UserInformation", b =>
                {
                    b.HasOne("MyHarvestApi.Entity.Model.Task", "Task")
                        .WithMany()
                        .HasForeignKey("IdTask");

                    b.HasOne("MyHarvestApi.Entity.Model.StatusOfTask", "StatusOfTask")
                        .WithMany()
                        .HasForeignKey("IdTaskStatus");

                    b.HasOne("MyHarvestApi.Entity.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser");
                });

            modelBuilder.Entity("MyHarvestApi.Entity.Model.UserTask", b =>
                {
                    b.HasOne("MyHarvestApi.Entity.Model.Task", "Task")
                        .WithMany()
                        .HasForeignKey("IdTask");

                    b.HasOne("MyHarvestApi.Entity.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser");
                });
#pragma warning restore 612, 618
        }
    }
}
