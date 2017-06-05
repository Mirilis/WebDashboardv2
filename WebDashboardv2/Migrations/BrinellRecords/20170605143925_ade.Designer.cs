using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebDashboardv2.Model;

namespace WebDashboardv2.Migrations.BrinellRecords
{
    [DbContext(typeof(BrinellRecordsContext))]
    [Migration("20170605143925_ade")]
    partial class ade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDashboardv2.Model.BossRangeData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Product");

                    b.Property<float>("RangeHigh");

                    b.Property<float>("RangeLow");

                    b.Property<string>("Specification");

                    b.HasKey("ID");

                    b.ToTable("RangeData");
                });

            modelBuilder.Entity("WebDashboardv2.Model.Records", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("BHNReading");

                    b.Property<string>("CastDate");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DateCast");

                    b.Property<string>("Product");

                    b.HasKey("ID");

                    b.ToTable("Records");
                });
        }
    }
}
