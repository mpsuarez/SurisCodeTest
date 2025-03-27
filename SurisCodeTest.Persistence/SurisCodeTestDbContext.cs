using Microsoft.EntityFrameworkCore;
using SurisCodeTest.Persistence.Entities;

namespace SurisCodeTest.Persistence
{
    public class SurisCodeTestDbContext : DbContext
    {


        public SurisCodeTestDbContext(DbContextOptions<SurisCodeTestDbContext> options) : base(options)
        {
        }

        public DbSet<Service> Service { get; set; }
        public DbSet<WorkingTime> WorkingTime { get; set; }
        public DbSet<ServiceWorkingTime> ServiceWorkingTime { get; set; }
        public DbSet<Reserve> Reserve { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
                entity.HasData(
                    new Service { Id = new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"), Name = "Servicio 1" },
                    new Service { Id = new Guid("07421f5a-3c0e-4dd4-8bcb-42ef8018e661"), Name = "Servicio 2" },
                    new Service { Id = new Guid("00ca27f5-d926-4d35-b120-5a9d43277e0b"), Name = "Servicio 3" },
                    new Service { Id = new Guid("753abd1c-ede5-4d56-aa09-083b9d266165"), Name = "Servicio 4" },
                    new Service { Id = new Guid("cf4ac3bb-9022-4dc3-9b29-6adaefdb6180"), Name = "Servicio 5" }
                );

            });

            modelBuilder.Entity<WorkingTime>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Time).IsRequired();
                entity.HasData(
                    new WorkingTime { Id = new Guid("a7996de4-4874-4998-80fc-5b34570ad802"), Time = new TimeOnly(8, 0) },
                    new WorkingTime { Id = new Guid("faa3f59a-1915-42aa-a703-dab4543afcf7"), Time = new TimeOnly(9, 0) },
                    new WorkingTime { Id = new Guid("b07906ec-c486-4aaa-b56e-e318a557afcb"), Time = new TimeOnly(10, 0) },
                    new WorkingTime { Id = new Guid("8bd023b7-4f09-4823-a2a7-d0d45df7223c"), Time = new TimeOnly(11, 0) },
                    new WorkingTime { Id = new Guid("164ff347-a959-476f-b0aa-2e36132b7b27"), Time = new TimeOnly(12, 0) }
                );
            });

            modelBuilder.Entity<ServiceWorkingTime>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.ServiceId).IsRequired();
                entity.Property(x => x.WorkingTimeId).IsRequired();

                entity.HasOne(x => x.Service)
                      .WithMany(x => x.ServiceWorkingTime)
                      .HasForeignKey(x => x.ServiceId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.WorkingTime)
                      .WithMany(x => x.ServiceWorkingTime)
                      .HasForeignKey(x => x.WorkingTimeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(x => new { x.ServiceId, x.WorkingTimeId }).IsUnique();

                entity.HasData(
                    // Service 1 Time : 8:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("4b4dce03-5d7d-4234-8aae-7b757ec0bffe"),
                        ServiceId = new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"),
                        WorkingTimeId = new Guid("a7996de4-4874-4998-80fc-5b34570ad802")
                    },
                    // Service 1 Time : 9:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("28a48cde-6f43-40c2-ad4d-b1ae806c368c"),
                        ServiceId = new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"),
                        WorkingTimeId = new Guid("faa3f59a-1915-42aa-a703-dab4543afcf7")
                    },
                    // Service 1 Time : 10:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("845137c8-a5b0-4612-8b5e-89a525ef6b83"),
                        ServiceId = new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"),
                        WorkingTimeId = new Guid("b07906ec-c486-4aaa-b56e-e318a557afcb")
                    },
                    // Service 1 Time : 11:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("bcae88c7-14b8-423a-9c10-6244365337d7"),
                        ServiceId = new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"),
                        WorkingTimeId = new Guid("8bd023b7-4f09-4823-a2a7-d0d45df7223c")
                    },
                    // Service 1 Time : 12:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("4332ca43-c21d-44b6-ac55-e0e236c2e628"),
                        ServiceId = new Guid("b7997635-1f0b-4fca-8f0d-c72eada760b5"),
                        WorkingTimeId = new Guid("164ff347-a959-476f-b0aa-2e36132b7b27")
                    },
                    // Service 2 Time : 8:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("e515ccd5-5364-44c3-ae10-2d09ac7f8ab3"),
                        ServiceId = new Guid("07421f5a-3c0e-4dd4-8bcb-42ef8018e661"),
                        WorkingTimeId = new Guid("a7996de4-4874-4998-80fc-5b34570ad802")
                    },
                    // Service 2 Time : 10:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("b5b9d36e-a8ef-459d-8e7a-c0ae6915ce92"),
                        ServiceId = new Guid("07421f5a-3c0e-4dd4-8bcb-42ef8018e661"),
                        WorkingTimeId = new Guid("b07906ec-c486-4aaa-b56e-e318a557afcb")
                    },
                    // Service 2 Time : 12:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("b82b553f-9b82-452c-9f5f-31a782ce0647"),
                        ServiceId = new Guid("07421f5a-3c0e-4dd4-8bcb-42ef8018e661"),
                        WorkingTimeId = new Guid("164ff347-a959-476f-b0aa-2e36132b7b27")
                    },
                    // Service 4 Time : 9:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("b5ae81b6-194e-43f7-adf0-acae019e54cf"),
                        ServiceId = new Guid("753abd1c-ede5-4d56-aa09-083b9d266165"),
                        WorkingTimeId = new Guid("faa3f59a-1915-42aa-a703-dab4543afcf7")
                    },
                    // Service 4 Time : 9:00
                    new ServiceWorkingTime
                    {
                        Id = new Guid("08732dd0-e9e4-4546-8739-c48f6560cfb4"),
                        ServiceId = new Guid("753abd1c-ede5-4d56-aa09-083b9d266165"),
                        WorkingTimeId = new Guid("8bd023b7-4f09-4823-a2a7-d0d45df7223c")
                    }
                );
            });

            modelBuilder.Entity<Reserve>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Date).IsRequired();
                entity.Property(x => x.ServiceWorkingTimeId).IsRequired();
                entity.Property(x => x.Client).IsRequired();

                entity.HasOne(x => x.ServiceWorkingTime)
                      .WithMany()
                      .HasForeignKey(x => x.ServiceWorkingTimeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(x => new { x.Date, x.ServiceWorkingTimeId }).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
