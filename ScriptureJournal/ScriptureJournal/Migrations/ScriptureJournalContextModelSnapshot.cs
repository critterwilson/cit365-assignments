﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScriptureJournal.Data;


namespace ScriptureJournal.Migrations
{
    [DbContext(typeof(ScriptureJournalContext))]
    partial class ScriptureJournalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("ScriptureJournal.Models.Scripture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Book")
                        .HasColumnType("TEXT");

                    b.Property<int>("Chapter")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<int>("Verse")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Scripture");
                });
#pragma warning restore 612, 618
        }
    }
}
