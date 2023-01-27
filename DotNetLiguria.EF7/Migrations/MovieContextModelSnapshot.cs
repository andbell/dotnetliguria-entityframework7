﻿// <auto-generated />
using System;
using DotNetLiguria.EF7;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNetLiguria.EF7.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotNetLiguria.EF7.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MovieId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstract")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<bool>("SerieTV")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Movies", (string)null);

                    b.HasDiscriminator<bool>("SerieTV").HasValue(false);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DotNetLiguria.EF7.Models.SerieTv", b =>
                {
                    b.HasBaseType("DotNetLiguria.EF7.Models.Movie");

                    b.HasDiscriminator().HasValue(true);
                });

            modelBuilder.Entity("DotNetLiguria.EF7.Models.Movie", b =>
                {
                    b.OwnsOne("DotNetLiguria.EF7.Models.Cast", "Cast", b1 =>
                        {
                            b1.Property<int>("MovieId")
                                .HasColumnType("int");

                            b1.HasKey("MovieId");

                            b1.ToTable("Movies");

                            b1.ToJson("Cast");

                            b1.WithOwner()
                                .HasForeignKey("MovieId");

                            b1.OwnsMany("DotNetLiguria.EF7.Models.Person", "Actors", b2 =>
                                {
                                    b2.Property<int>("CastMovieId")
                                        .HasColumnType("int");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<string>("FullName")
                                        .HasMaxLength(512)
                                        .HasColumnType("nvarchar(512)");

                                    b2.HasKey("CastMovieId", "Id");

                                    b2.ToTable("Movies");

                                    b2.WithOwner()
                                        .HasForeignKey("CastMovieId");
                                });

                            b1.OwnsMany("DotNetLiguria.EF7.Models.Person", "Directors", b2 =>
                                {
                                    b2.Property<int>("CastMovieId")
                                        .HasColumnType("int");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<string>("FullName")
                                        .HasMaxLength(512)
                                        .HasColumnType("nvarchar(512)");

                                    b2.HasKey("CastMovieId", "Id");

                                    b2.ToTable("Movies");

                                    b2.WithOwner()
                                        .HasForeignKey("CastMovieId");
                                });

                            b1.Navigation("Actors");

                            b1.Navigation("Directors");
                        });

                    b.OwnsOne("DotNetLiguria.EF7.Models.MovieInfo", "Info", b1 =>
                        {
                            b1.Property<int>("MovieId")
                                .HasColumnType("int");

                            b1.Property<int?>("Duration")
                                .HasColumnType("int");

                            b1.Property<string>("Genres")
                                .HasMaxLength(512)
                                .HasColumnType("nvarchar(512)");

                            b1.Property<string>("Nationality")
                                .HasMaxLength(512)
                                .HasColumnType("nvarchar(512)");

                            b1.Property<string>("Rated")
                                .HasMaxLength(512)
                                .HasColumnType("nvarchar(512)");

                            b1.Property<int?>("Year")
                                .HasColumnType("int");

                            b1.HasKey("MovieId");

                            b1.ToTable("Movies");

                            b1.ToJson("Info");

                            b1.WithOwner()
                                .HasForeignKey("MovieId");
                        });

                    b.OwnsOne("DotNetLiguria.EF7.Models.Seasons", "Seasons", b1 =>
                        {
                            b1.Property<int>("MovieId")
                                .HasColumnType("int");

                            b1.HasKey("MovieId");

                            b1.ToTable("Movies");

                            b1.ToJson("Seasons");

                            b1.WithOwner()
                                .HasForeignKey("MovieId");

                            b1.OwnsMany("DotNetLiguria.EF7.Models.Episode", "Episodes", b2 =>
                                {
                                    b2.Property<int>("SeasonsMovieId")
                                        .HasColumnType("int");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<int?>("Duration")
                                        .HasColumnType("int");

                                    b2.Property<int?>("Number")
                                        .HasColumnType("int");

                                    b2.Property<int?>("Season")
                                        .HasColumnType("int");

                                    b2.Property<string>("Title")
                                        .HasMaxLength(512)
                                        .HasColumnType("nvarchar(512)");

                                    b2.HasKey("SeasonsMovieId", "Id");

                                    b2.ToTable("Movies");

                                    b2.WithOwner()
                                        .HasForeignKey("SeasonsMovieId");
                                });

                            b1.Navigation("Episodes");
                        });

                    b.Navigation("Cast");

                    b.Navigation("Info");

                    b.Navigation("Seasons");
                });
#pragma warning restore 612, 618
        }
    }
}
