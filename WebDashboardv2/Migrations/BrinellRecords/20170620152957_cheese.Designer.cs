using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebDashboardv2.Model;

namespace WebDashboardv2.Migrations.BrinellRecords
{
    [DbContext(typeof(BrinellRecordsContext))]
    [Migration("20170620152957_cheese")]
    partial class cheese
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDashboardv2.Model.FileManagerHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileData");

                    b.Property<string>("FileName");

                    b.Property<DateTime>("UploadDate");

                    b.HasKey("ID");

                    b.ToTable("FileManagerHistory");
                });

            modelBuilder.Entity("WebDashboardv2.Model.HistoricalRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CastDate");

                    b.Property<string>("CastDateString");

                    b.Property<string>("CavityNumber");

                    b.Property<string>("Comment");

                    b.Property<string>("Customer");

                    b.Property<string>("HeatTreated");

                    b.Property<string>("Product");

                    b.Property<string>("Range");

                    b.Property<double>("Reading");

                    b.Property<DateTime?>("ReadingDate");

                    b.Property<string>("ShiftAmount");

                    b.Property<string>("Specification");

                    b.HasKey("ID");

                    b.ToTable("HistoricalRecords");
                });

            modelBuilder.Entity("WebDashboardv2.Model.ProductionHardnessSummary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BHNCount");

                    b.Property<DateTime>("Date");

                    b.Property<float?>("Max");

                    b.Property<float?>("Minimum");

                    b.Property<string>("Product");

                    b.Property<int?>("Quantity");

                    b.Property<float?>("RangeHigh");

                    b.Property<float?>("RangeLow");

                    b.HasKey("ID");

                    b.ToTable("ProductionWithHBWByPartAndDay");
                });

            modelBuilder.Entity("WebDashboardv2.Model.RangeData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("HighWarn");

                    b.Property<double?>("LowWarn");

                    b.Property<string>("Product");

                    b.Property<double?>("RangeHigh");

                    b.Property<double?>("RangeLow");

                    b.Property<string>("Specification");

                    b.HasKey("ID");

                    b.ToTable("BossRangeData");
                });

            modelBuilder.Entity("WebDashboardv2.Model.Record", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CastDate");

                    b.Property<string>("CastDateString");

                    b.Property<string>("CavityNumber");

                    b.Property<string>("Comment");

                    b.Property<string>("Customer");

                    b.Property<string>("HeatTreated");

                    b.Property<string>("Product");

                    b.Property<string>("Range");

                    b.Property<double>("Reading");

                    b.Property<DateTime?>("ReadingDate");

                    b.Property<string>("ShiftAmount");

                    b.Property<string>("Specification");

                    b.HasKey("ID");

                    b.ToTable("ValidRecords");
                });

            modelBuilder.Entity("WebDashboardv2.Model.SuspectRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CastDate");

                    b.Property<string>("CastDateString");

                    b.Property<string>("CavityNumber");

                    b.Property<string>("Comment");

                    b.Property<string>("Customer");

                    b.Property<string>("HeatTreated");

                    b.Property<string>("Product");

                    b.Property<string>("Range");

                    b.Property<double>("Reading");

                    b.Property<DateTime?>("ReadingDate");

                    b.Property<string>("ShiftAmount");

                    b.Property<string>("Specification");

                    b.HasKey("ID");

                    b.ToTable("SuspectRecords");
                });
        }
    }
}
