using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebDashboardv2.Model;

namespace WebDashboardv2.Migrations
{
    [DbContext(typeof(ProcessCardContext))]
    [Migration("20170605130336_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebDashboardv2.Model.Approver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.Property<int>("ValidAccess");

                    b.Property<string>("WindowsName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Approvers");
                });

            modelBuilder.Entity("WebDashboardv2.Model.BlisCoresView", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15);

                    b.Property<string>("ActiveStatus");

                    b.Property<string>("BaseCoreNumber");

                    b.Property<string>("Box");

                    b.Property<string>("CoreWeightPerCavityOrFamilySet");

                    b.Property<string>("CoresPerFamily");

                    b.Property<string>("MachineType");

                    b.Property<string>("ProductNumber");

                    b.HasKey("ID");

                    b.ToTable("BlisCoresView");
                });

            modelBuilder.Entity("WebDashboardv2.Model.BlisCustomersView", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressL1");

                    b.Property<string>("AddressL2");

                    b.Property<string>("City");

                    b.Property<string>("CustomerName");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("CustomerNumber");

                    b.ToTable("BlisCustomersView");
                });

            modelBuilder.Entity("WebDashboardv2.Model.BlisProductsView", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActiveStatus");

                    b.Property<string>("CastingWeight");

                    b.Property<string>("CustomerNumber");

                    b.Property<string>("Description");

                    b.Property<string>("Impressions");

                    b.Property<string>("MoldCenter");

                    b.Property<string>("PourWeight");

                    b.Property<string>("Product");

                    b.HasKey("ID");

                    b.ToTable("BlisProductsView");
                });

            modelBuilder.Entity("WebDashboardv2.Model.DataPoint", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<int>("ApproverID");

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<int?>("ProcessCardID");

                    b.Property<string>("Type");

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.HasIndex("ApproverID");

                    b.HasIndex("ProcessCardID");

                    b.ToTable("DataPoints");
                });

            modelBuilder.Entity("WebDashboardv2.Model.ProcessCard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProcessCardClass");

                    b.Property<string>("ProductName")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("ProcessCards");
                });

            modelBuilder.Entity("WebDashboardv2.Model.ProcessCardKey", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<int>("ProcessCardClass");

                    b.HasKey("ID");

                    b.ToTable("ProcessCardKeys");
                });

            modelBuilder.Entity("WebDashboardv2.Model.ProductAlert", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionRequired");

                    b.Property<DateTime>("AlertDate");

                    b.Property<string>("AuthorizedBy");

                    b.Property<string>("Comments");

                    b.Property<int>("CustomerNumber");

                    b.Property<int>("Departments");

                    b.Property<string>("Description");

                    b.Property<string>("Image1Path");

                    b.Property<string>("Image2Path");

                    b.Property<string>("Image3Path");

                    b.Property<string>("Image4Path");

                    b.Property<string>("ProductNumber");

                    b.Property<int>("Quantity");

                    b.Property<int>("RepeatCount");

                    b.Property<string>("RootCause");

                    b.Property<string>("TemplateTypePath");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("ProductAlerts");
                });

            modelBuilder.Entity("WebDashboardv2.Model.DataPoint", b =>
                {
                    b.HasOne("WebDashboardv2.Model.Approver", "Approver")
                        .WithMany("DataPoints")
                        .HasForeignKey("ApproverID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebDashboardv2.Model.ProcessCard")
                        .WithMany("DataPoints")
                        .HasForeignKey("ProcessCardID");
                });
        }
    }
}
