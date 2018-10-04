﻿// <auto-generated />
using System;
using JustBlog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JustBlog.Migrations
{
    [DbContext(typeof(JustBlogContext))]
    partial class JustBlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JustBlog.Persistence.Entities.AccountEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("ID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("JustBlog.Persistence.Entities.CategoryEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("JustBlog.Persistence.Entities.PostCategoryEntity", b =>
                {
                    b.Property<Guid>("PostID");

                    b.Property<Guid>("CategoryID");

                    b.HasKey("PostID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("PostCategoryEntity");
                });

            modelBuilder.Entity("JustBlog.Persistence.Entities.PostEntity", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorID");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("MainContent")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("ntext");

                    b.Property<string>("Slug")
                        .HasMaxLength(250);

                    b.Property<byte[]>("ThumbnailImage");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true);

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Date")
                        .HasDefaultValueSql("GetDate()");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("JustBlog.Persistence.Entities.PostCategoryEntity", b =>
                {
                    b.HasOne("JustBlog.Persistence.Entities.CategoryEntity", "Category")
                        .WithMany("PostCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JustBlog.Persistence.Entities.PostEntity", "Post")
                        .WithMany("PostCategories")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JustBlog.Persistence.Entities.PostEntity", b =>
                {
                    b.HasOne("JustBlog.Persistence.Entities.AccountEntity", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
