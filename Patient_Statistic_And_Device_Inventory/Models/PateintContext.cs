using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Patient_Statistic_And_Device_Inventory.Models
{

    public class PateintContext:DbContext
    {
        public PateintContext()
        {

        }
        public PateintContext(DbContextOptions<PateintContext> options):base(options)
        {

        }
        public virtual DbSet<Patient_Statistics> patient_statistics { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient_Statistics>(entity =>
            {
                entity.HasKey(s => s.Serial_No);

                entity.ToTable("Patient_Statistics");

                //entity.Property(e => e.Student_Id).HasColumnName("Student_Id");

                entity.Property(e => e.Total_Practices).HasColumnName("Total_Practices");

                entity.Property(e => e.Active_Practices).HasColumnName("Active_Practices");
                entity.Property(e => e.InActive_Practices).HasColumnName("InActive_Practices");
                entity.Property(e => e.Total_Vendors).HasColumnName("Total_Vendors");
                entity.Property(e => e.CCM_Patient).HasColumnName("CCM_Patient");
                entity.Property(e => e.RTM_Patient).HasColumnName("RTM_Patient");
                entity.Property(e => e.RPM_Patient).HasColumnName("RPM_Patient");
                entity.Property(e => e.Available_Device).HasColumnName("Available_Device");
                entity.Property(e => e.Allowcated_Device).HasColumnName("Allowcated_Device");
                entity.Property(e => e.Mal_Functioned_Devices).HasColumnName("Mal_Functioned_Devices");
                entity.Property(e => e.Reterive_Device).HasColumnName("Reterive_Device");
                entity.Property(e => e.Practice_Admin).HasColumnName("Practice_Admin");
                entity.Property(e => e.Medical_Assistant).HasColumnName("Medical_Assistant");
                entity.Property(e => e.Staff).HasColumnName("Staff");
            });


        }

    }


    }

