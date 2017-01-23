using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ImageDatabase.Entities;

namespace ImageDatabase.Migrations
{
    [DbContext(typeof(ImageDatabaseDbContext))]
    [Migration("20161226191158_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImageDatabase.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ImageBytes")
                        .IsRequired();

                    b.Property<string>("ImageType")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Images");
                });
        }
    }
}
