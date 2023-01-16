using Microsoft.EntityFrameworkCore;
using VirtualLaboratory.Domain.Entity;

#nullable disable

namespace VirtualLaboratory.DAL
{
    public partial class VirtualLaboratoryContext : DbContext
    {
        public VirtualLaboratoryContext()
        {
        }

        public VirtualLaboratoryContext(DbContextOptions<VirtualLaboratoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Constant> Constants { get; set; }
        public virtual DbSet<ConstantInLaboratoryWork> ConstantInLaboratoryWorks { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentParametr> EquipmentParametrs { get; set; }
        public virtual DbSet<Installation> Installations { get; set; }
        public virtual DbSet<LaboratoryWork> LaboratoryWorks { get; set; }
        public virtual DbSet<MistakeInReport> MistakeInReports { get; set; }
        public virtual DbSet<Phenomenon> Phenomena { get; set; }
        public virtual DbSet<PhenomenonInLaboratoryWork> PhenomenonInLaboratoryWorks { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<ProcessInPhenomenon> ProcessInPhenomena { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<TheoreticalInformation> TheoreticalInformations { get; set; }
        public virtual DbSet<TheoreticalInformationForLaboratoryWork> TheoreticalInformationForLaboratoryWorks { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-RTPDA1J;Database=VirtualLaboratory;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Constant>(entity =>
            {
                entity.ToTable("Constant");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Si)
                    .IsRequired()
                    .HasColumnName("SI");
            });

            modelBuilder.Entity<ConstantInLaboratoryWork>(entity =>
            {
                entity.ToTable("ConstantInLaboratoryWork");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdConstant).HasColumnName("ID_Constant");

                entity.Property(e => e.IdLaboratoryWork).HasColumnName("ID_LaboratoryWork");

                entity.HasOne(d => d.IdConstantNavigation)
                    .WithMany(p => p.ConstantInLaboratoryWorks)
                    .HasForeignKey(d => d.IdConstant)
                    .HasConstraintName("FK_ConstantInLaboratoryWork_Constant");

                entity.HasOne(d => d.IdLaboratoryWorkNavigation)
                    .WithMany(p => p.ConstantInLaboratoryWorks)
                    .HasForeignKey(d => d.IdLaboratoryWork)
                    .HasConstraintName("FK_ConstantInLaboratoryWork_LaboratoryWork");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdInstallation).HasColumnName("ID_Installation");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.IdInstallationNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.IdInstallation)
                    .HasConstraintName("FK_Equipment_Installation");
            });

            modelBuilder.Entity<EquipmentParametr>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdEquipment).HasColumnName("ID_Equipment");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Si)
                    .IsRequired()
                    .HasColumnName("SI");

                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.IdEquipmentNavigation)
                    .WithMany(p => p.EquipmentParametrs)
                    .HasForeignKey(d => d.IdEquipment)
                    .HasConstraintName("FK_EquipmentParametrs_Equipment");
            });

            modelBuilder.Entity<Installation>(entity =>
            {
                entity.ToTable("Installation");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdLaboratoryWork).HasColumnName("ID_LaboratoryWork");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.IdLaboratoryWorkNavigation)
                    .WithMany(p => p.Installations)
                    .HasForeignKey(d => d.IdLaboratoryWork)
                    .HasConstraintName("FK_Installation_LaboratoryWork");
            });

            modelBuilder.Entity<LaboratoryWork>(entity =>
            {
                entity.ToTable("LaboratoryWork");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Objective).IsRequired();
            });

            modelBuilder.Entity<MistakeInReport>(entity =>
            {
                entity.ToTable("MistakeInReport");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdReport).HasColumnName("ID_Report");

                entity.Property(e => e.Mistake).IsRequired();

                entity.HasOne(d => d.IdReportNavigation)
                    .WithMany(p => p.MistakeInReports)
                    .HasForeignKey(d => d.IdReport)
                    .HasConstraintName("FK_MistakeInReport_Report");
            });

            modelBuilder.Entity<Phenomenon>(entity =>
            {
                entity.ToTable("Phenomenon");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<PhenomenonInLaboratoryWork>(entity =>
            {
                entity.ToTable("PhenomenonInLaboratoryWork");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdLaboratoryWork).HasColumnName("ID_LaboratoryWork");

                entity.Property(e => e.IdPhenomenon).HasColumnName("ID_Phenomenon");

                entity.HasOne(d => d.IdLaboratoryWorkNavigation)
                    .WithMany(p => p.PhenomenonInLaboratoryWorks)
                    .HasForeignKey(d => d.IdLaboratoryWork)
                    .HasConstraintName("FK_PhenomenonInLaboratoryWork_LaboratoryWork");

                entity.HasOne(d => d.IdPhenomenonNavigation)
                    .WithMany(p => p.PhenomenonInLaboratoryWorks)
                    .HasForeignKey(d => d.IdPhenomenon)
                    .HasConstraintName("FK_PhenomenonInLaboratoryWork_Phenomenon");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("Process");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ProcessInPhenomenon>(entity =>
            {
                entity.ToTable("ProcessInPhenomenon");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdPhenomenon).HasColumnName("ID_Phenomenon");

                entity.Property(e => e.IdProcess).HasColumnName("ID_Process");

                entity.HasOne(d => d.IdPhenomenonNavigation)
                    .WithMany(p => p.ProcessInPhenomena)
                    .HasForeignKey(d => d.IdPhenomenon)
                    .HasConstraintName("FK_ProcessInPhenomenon_Phenomenon");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.ProcessInPhenomena)
                    .HasForeignKey(d => d.IdProcess)
                    .HasConstraintName("FK_ProcessInPhenomenon_Process");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.IdLaboratoryWork).HasColumnName("ID_LaboratoryWork");

                entity.HasOne(d => d.IdLaboratoryWorkNavigation)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.IdLaboratoryWork)
                    .HasConstraintName("FK_Report_LaboratoryWork");
            });

            modelBuilder.Entity<TheoreticalInformation>(entity =>
            {
                entity.ToTable("TheoreticalInformation");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<TheoreticalInformationForLaboratoryWork>(entity =>
            {
                entity.ToTable("TheoreticalInformationForLaboratoryWork");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdLaboratoryWork).HasColumnName("ID_LaboratoryWork");

                entity.Property(e => e.IdTheoreticalInformation).HasColumnName("ID_TheoreticalInformation");

                entity.HasOne(d => d.IdLaboratoryWorkNavigation)
                    .WithMany(p => p.TheoreticalInformationForLaboratoryWorks)
                    .HasForeignKey(d => d.IdLaboratoryWork)
                    .HasConstraintName("FK_TheoreticalInformationForLaboratoryWork_LaboratoryWork");

                entity.HasOne(d => d.IdTheoreticalInformationNavigation)
                    .WithMany(p => p.TheoreticalInformationForLaboratoryWorks)
                    .HasForeignKey(d => d.IdTheoreticalInformation)
                    .HasConstraintName("FK_TheoreticalInformationForLaboratoryWork_TheoreticalInformation");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
