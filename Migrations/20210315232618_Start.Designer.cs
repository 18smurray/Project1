// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project1.Models;

namespace Project1.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210315232618_Start")]
    partial class Start
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13");

            modelBuilder.Entity("Project1.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("AppointmentID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Project1.Models.Timeslot", b =>
                {
                    b.Property<int>("TimeslotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppointmentID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Booked")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("TimeslotID");

                    b.HasIndex("AppointmentID");

                    b.ToTable("Timeslots");
                });

            modelBuilder.Entity("Project1.Models.Timeslot", b =>
                {
                    b.HasOne("Project1.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentID");
                });
#pragma warning restore 612, 618
        }
    }
}
