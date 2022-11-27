﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamManagementApp.Database;

namespace TeamManagementApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221126132617_InitialMigration1")]
    partial class InitialMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeamManagementApp.Models.Interest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FavoriteDish")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Hobby1")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Hobby2")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("TeamMembersID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamMembersID");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("TeamManagementApp.Models.Mark", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DBMS")
                        .HasColumnType("int");

                    b.Property<int>("DataStructure")
                        .HasColumnType("int");

                    b.Property<int>("Java")
                        .HasColumnType("int");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("NanoMechanics")
                        .HasColumnType("int");

                    b.Property<int?>("TeamMembersID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamMembersID");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("TeamManagementApp.Models.TeamInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("College")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollegeEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollegeProgram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamMembersID")
                        .HasColumnType("int");

                    b.Property<string>("YearInProgram")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("TeamMembersID");

                    b.ToTable("TeamInfos");
                });

            modelBuilder.Entity("TeamManagementApp.Models.TeamMember", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ID");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("TeamManagementApp.Models.Interest", b =>
                {
                    b.HasOne("TeamManagementApp.Models.TeamMember", "TeamMembers")
                        .WithMany("Interests")
                        .HasForeignKey("TeamMembersID");
                });

            modelBuilder.Entity("TeamManagementApp.Models.Mark", b =>
                {
                    b.HasOne("TeamManagementApp.Models.TeamMember", "TeamMembers")
                        .WithMany("Marks")
                        .HasForeignKey("TeamMembersID");
                });

            modelBuilder.Entity("TeamManagementApp.Models.TeamInfo", b =>
                {
                    b.HasOne("TeamManagementApp.Models.TeamMember", "TeamMembers")
                        .WithMany("TeamInfo")
                        .HasForeignKey("TeamMembersID");
                });
#pragma warning restore 612, 618
        }
    }
}
