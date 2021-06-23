﻿// <auto-generated />
using System;
using DragonQuestNine.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DragonQuestNine.Migrations
{
    [DbContext(typeof(DragonQuestDbContext))]
    [Migration("20210622173224_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DragonQuestNine.Models.Accolade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccoladeCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateObtained")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsObtained")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("AccoladeCategoryId");

                    b.ToTable("Accolades");
                });

            modelBuilder.Entity("DragonQuestNine.Models.AccoladeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("AccoladeCategories");
                });

            modelBuilder.Entity("DragonQuestNine.Models.Accolade", b =>
                {
                    b.HasOne("DragonQuestNine.Models.AccoladeCategory", "AccoladeCategory")
                        .WithMany("Accolades")
                        .HasForeignKey("AccoladeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccoladeCategory");
                });

            modelBuilder.Entity("DragonQuestNine.Models.AccoladeCategory", b =>
                {
                    b.Navigation("Accolades");
                });
#pragma warning restore 612, 618
        }
    }
}